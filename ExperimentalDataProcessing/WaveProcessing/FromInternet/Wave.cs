using System;
using System.IO;

namespace WaveProcessing
{
    public class Wave
    {
        public double[][] DataSamples { get; set; }
        public int CompressionCode { get; private set; }
        public int NumberOfChannels { get; private set; }
        public int SampleRate { get; private set; }
        public int AverageBytesPerSecond { get; private set; }
        public int SignificantBitsPerSample { get; private set; }
        public int BlockAlign { get; private set; }
        public int Frames { get; private set; }
        public int StartPosition { get; private set; }
        public int chunkLength { get; private set; }
        public double TimeLength { get; private set; }

        /// <summary>
        /// Reads a Wave file from the input stream, but don't closes the stream
        /// </summary>
        /// <param name="stream">Input WAVE file stream</param>
        public Wave(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            try
            {
                if (new string(br.ReadChars(4)).ToUpper() == "RIFF")
                {
                    int length = br.ReadInt32();
                    if (new string(br.ReadChars(4)).ToUpper() == "WAVE")
                    {
                        string chunkName = new string(br.ReadChars(4)); //"fmt "
                        this.chunkLength = br.ReadInt32();
                        this.CompressionCode = br.ReadInt16(); //1 for PCM/uncompressed
                        this.NumberOfChannels = br.ReadInt16();
                        this.SampleRate = br.ReadInt32();
                        this.AverageBytesPerSecond = br.ReadInt32();
                        this.BlockAlign = br.ReadInt16();
                        this.SignificantBitsPerSample = br.ReadInt16();
                        if (this.SignificantBitsPerSample == 0)
                            throw new Exception("The input stream uses an unhandled SignificantBitsPerSample parameter");
                        if (chunkLength > 16)
                        {
                            br.ReadChars(chunkLength - 16);
                        }
                        chunkName = new string(br.ReadChars(4));
                        try
                        {
                            while (chunkName.ToLower() != "data")
                            {
                                br.ReadChars(br.ReadInt32());
                                chunkName = new string(br.ReadChars(4));
                            }
                            StartPosition = (int)br.BaseStream.Position + 4;
                        }
                        catch
                        {
                            throw new Exception("Input stream misses the data chunk");
                        }
                        chunkLength = br.ReadInt32();
                        try
                        {
                            this.Frames = 8 * (chunkLength / this.SignificantBitsPerSample) / this.NumberOfChannels;
                        }
                        catch
                        {
                            throw new Exception("The input stream has zero channels");
                        }
                        this.TimeLength = ((double)this.Frames) / ((double)this.SampleRate);
                        this.DataSamples = new double[this.NumberOfChannels][];
                        for (int j = 0; j < this.NumberOfChannels; j++)
                        {
                            this.DataSamples[j] = new double[this.Frames];
                        }
                        switch (SignificantBitsPerSample)
                        {
                            case 4:
                                Byte b = new Byte();
                                bool IsEven = true;
                                for (int i = 0; i < this.Frames; i++)
                                {
                                    for (int j = 0; j < this.NumberOfChannels; j++)
                                    {
                                        if (IsEven)
                                        {
                                            b = br.ReadByte();
                                            DataSamples[j][i] = Convert.ToInt32((b >> 4) & 0x0F);
                                        }
                                        else
                                        {
                                            DataSamples[j][i] = Convert.ToInt32(b & 0x0F);
                                        }
                                        IsEven = !IsEven;
                                    }
                                }
                                break;
                            case 8:
                                for (int i = 0; i < this.Frames; i++)
                                {
                                    for (int j = 0; j < this.NumberOfChannels; j++)
                                    {
                                        DataSamples[j][i] = Convert.ToInt32(br.ReadByte());
                                    }
                                }
                                break;
                            case 16:
                                for (int i = 0; i < this.Frames; i++)
                                {
                                    for (int j = 0; j < this.NumberOfChannels; j++)
                                    {
                                        DataSamples[j][i] = br.ReadInt16();
                                    }
                                }
                                break;
                            case 24:
                                for (int i = 0; i < this.Frames; i++)
                                {
                                    for (int j = 0; j < this.NumberOfChannels; j++)
                                    {
                                        Byte[] int24 = br.ReadBytes(3);
                                        DataSamples[j][i] = Convert.ToInt32(int24[0]) + (Convert.ToInt32(int24[1]) << 8) + (Convert.ToInt32(int24[3]) << 16);
                                    }
                                }
                                break;
                            case 32:
                                for (int i = 0; i < Frames; i++)
                                {
                                    for (int j = 0; j < this.NumberOfChannels; j++)
                                    {
                                        DataSamples[j][i] = br.ReadInt32();
                                    }
                                }
                                break;
                            default:
                                throw new Exception("The input stream uses an unhandled SignificantBitsPerSample parameter");
                        }
                    }
                    else
                    {
                        throw new Exception("Input stream doesn't comply with the WAVE specification");
                    }
                }
                else
                {
                    throw new Exception("Input stream doesn't comply with the RIFF specification");
                }
            }
            finally
            {
                br.Close();
            }
        }
    }

}

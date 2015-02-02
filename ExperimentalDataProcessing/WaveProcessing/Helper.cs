
namespace WaveProcessing
{
    public static class Helper
    {
        /// <summary>
        /// Обмен значениями двух переменных любого типа 
        /// </summary>
        /// <param name="a">Переменная 1</param>
        /// <param name="b">Переменная 2</param>
        public static void Swap<T>(T a, T b) { T tmp = a; a = b; b = tmp; }
    }
 
}

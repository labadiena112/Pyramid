using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyramid_Milvydas
{
    public class Pyramid
    {
        List<List<int>> pyramid = new List<List<int>>() { //su failu galim irgi sujungti
                new List<int>() { 215 },
                new List<int>() { 192, 124 },
                new List<int>() { 117, 269, 442 },
                new List<int>() { 218, 836, 347, 235 },
                new List<int>() { 320, 805, 522, 417, 345 },
                new List<int>() { 229, 601, 728, 835, 133, 124 },
                new List<int>() { 248, 202, 277, 433, 207, 263, 257 },
                new List<int>() { 359, 464, 504, 528, 516, 716, 871, 182 },
                new List<int>() { 461, 441, 426, 656, 863, 560, 380, 171, 923 },
                new List<int>() { 381, 348, 573, 533, 448, 632, 387, 176, 975, 449 },
                new List<int>() { 223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444 },
                new List<int>() { 330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197 },
                new List<int>() { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928 },
                new List<int>() { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121 },
                new List<int>() { 924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230, 124, 233 },
            };

        public List<List<int>> paths = new List<List<int>>();

        public Pyramid()
        {

        }

        public int PathSum(List<int> path)
        {
            int sum = 0;
            for (int i = 0; i < path.Count; i++) {
                sum += path[i];
            }
            return sum;
        }

        public List<List<int>> GetMaxSumPaths()
        {
            paths.Add(new List<int>() { pyramid[0][0] });
            RecurrsivePyramidScanning(1, 0, 0);
            List<int> pathSums = new List<int>();
            for (int i = 0; i < paths.Count; i++) {
                pathSums.Add(PathSum(paths[i])); //keliu issisakojimas
            }
            int maxSum = pathSums.Max();
            List<List<int>> maxPaths = new List<List<int>>(); //surandom visus, jeigu yra sutampanciu max sumu
            for (int i = 0; i < pathSums.Count; i++) {
                if (maxSum == pathSums[i]) maxPaths.Add(paths[i]);
            }
            for (int i = 0; i < maxPaths.Count; i++) {
                Console.WriteLine($"{string.Join(" + ", maxPaths[i])} = {maxSum}");
            }
            return maxPaths;
        }

        public void RecurrsivePyramidScanning(int row, int column, int pathIndex)
        {
            if (row >= pyramid.Count) return;
            List<int> nearbyIndexes = new List<int>(); //laikomi galimi keliu issisakojimai
            int lastPathNumber = paths[pathIndex][paths[pathIndex].Count - 1]; //gaunam paskutini skaiciu, dabartinio kelio
            bool even = Convert.ToBoolean(lastPathNumber % 2 == 0); //lyginis ar nelyginis buvo
            if (pyramid[row].Count > column + 1 && even != Convert.ToBoolean(pyramid[row][column+1] % 2 == 0)) nearbyIndexes.Add(column + 1);
            if (even != Convert.ToBoolean(pyramid[row][column] % 2 == 0)) nearbyIndexes.Add(column);
            if (column - 1 >= 0 && even != Convert.ToBoolean(pyramid[row][column - 1] % 2 == 0)) nearbyIndexes.Add(column - 1);
            if (nearbyIndexes.Count > 1) { //reikalingi papildomi ciklai, skaiciavimai
                List<int> mainPathCopy = new List<int>();
                mainPathCopy.AddRange(paths[pathIndex].ToArray()); //pridedam visus skaicius
                paths.RemoveAt(pathIndex);
                for (int i = 0; i < nearbyIndexes.Count; i++) {
                    List<int> newPathWays = new List<int>();
                    newPathWays.AddRange(mainPathCopy); //pridedam visa sena kelia
                    newPathWays.Add(pyramid[row][nearbyIndexes[i]]); //pridedam nauja skaiciu prie naujo issisakojimo
                    paths.Add(newPathWays);
                    RecurrsivePyramidScanning(row + 1, nearbyIndexes[i], paths.IndexOf(newPathWays)); //einam zemyn piramides per viena
                }
            }
            else if (nearbyIndexes.Count == 1) { //atitiko tik 1 kelias
                paths[pathIndex].Add(pyramid[row][nearbyIndexes[0]]); //pridedam
                RecurrsivePyramidScanning(row + 1, nearbyIndexes[0], pathIndex); //einam zemyn piramides per viena
            }
        }
    }
}

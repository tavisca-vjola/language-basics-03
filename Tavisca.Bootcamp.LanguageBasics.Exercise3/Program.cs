using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
                
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
               new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
                
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int maximum(int[] array)
        {
            return array.Max();
        }
        public static int minimum(int[] array)
        {
            return array.Min();
        }
        public static int findind(int ind, int[] ans)
        {
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] == ind)
                    return i;
            }
            return -1;
        }
        public static int findmax(int[] pattern, int[] text)
        {
            int maxi = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (pattern[text[i]] > maxi)
                {
                    maxi = pattern[text[i]];
                }
            }
            return maxi;
        }
        public static int findmin(int[] pattern, int[] text)
        {
            int maxi = 10000;
            for (int i = 0; i < text.Length; i++)
            {
                if (pattern[text[i]] < maxi)
                {
                    maxi = pattern[text[i]];
                }
            }
            return maxi;
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] totalcalories = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
            {
                totalcalories[i] = protein[i] + carbs[i] + fat[i];
            }
            int[] countP = new int[15000];
            int[] countC = new int[15000];
            int[] countF = new int[15000];
            int[] countT = new int[15000];
            for (int i = 0; i < protein.Length; i++)
            {
                countP[protein[i]]++;
                countC[carbs[i]]++;
                countF[fat[i]]++;
                countT[totalcalories[i]]++;
            }
            int[] ans=new int[10];
            ArrayList a = new ArrayList();
            int flag, count;
            foreach (string x in dietPlans)
            {
                flag = 0;
                count =-1;
                   if(x=="")
                {
                    a.Add(0);
                }
                   else
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        // Console.WriteLine(i);
                        count++;
                        if (x[i] == 'P')
                        {

                            if (i == 0)
                            {

                                flag = 1;
                                int ind = maximum(protein);
                                if (countP[ind] == 1)
                                {
                                    int an = findind(ind, protein);
                                    // Console.WriteLine(an);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = protein.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(protein, ans);
                                    if (countP[max] == 1)
                                    {
                                        int an = findind(max, protein);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = protein.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {

                                    int max = findmin(protein, ans);
                                    if (countP[max] == 1)
                                    {
                                        int an = findind(max, protein);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = protein.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                        else if (x[i] == 'C')
                        {

                            if (i == 0)
                            {

                                flag = 1;
                                int ind = maximum(carbs);
                                if (countC[ind] == 1)
                                {
                                    int an = findind(ind, carbs);

                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = carbs.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(carbs, ans);
                                    if (countC[max] == 1)
                                    {
                                        int an = findind(max, carbs);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = carbs.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmax(carbs, ans);
                                    if (countC[max] == 1)
                                    {
                                        int an = findind(max, carbs);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = carbs.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }

                        }

                        else if (x[i] == 'F')
                        {

                            if (i == 0)
                            {

                                flag = 1;
                                int ind = maximum(fat);
                                if (countF[ind] == 1)
                                {
                                    int an = findind(ind, fat);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = fat.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(carbs, ans);
                                    if (countF[max] == 1)
                                    {
                                        int an = findind(max, carbs);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(fat, ans);
                                    //Console.WriteLine(max);
                                    if (countF[max] == 1)
                                    {
                                        int an = findind(max, fat);
                                        a.Add(an);
                                        //Console.WriteLine(max);
                                        break;
                                    }
                                    else
                                    {
                                        //Console.WriteLine(count);
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);

                                            break;
                                        }
                                        else
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }

                            }

                        }
                        else if (x[i] == 'T')
                        {

                            if (i == 0)
                            {

                                flag = 1;
                                int ind = maximum(totalcalories);
                                if (countT[ind] == 1)
                                {
                                    int an = findind(ind, totalcalories);
                                    //Console.WriteLine(an);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = totalcalories.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(totalcalories, ans);
                                    if (countT[max] == 1)
                                    {
                                        int an = findind(max, totalcalories);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = totalcalories.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(totalcalories, ans);
                                    if (countT[max] == 1)
                                    {
                                        int an = findind(max, totalcalories);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = totalcalories.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }

                            }

                        }
                        else if (x[i] == 'c')
                        {

                            if (i == 0)
                            {

                                flag = 0;
                                int ind = minimum(carbs);
                                if (countC[ind] == 1)
                                {
                                    int an = findind(ind, carbs);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = carbs.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(carbs, ans);
                                    if (countC[max] == 1)
                                    {
                                        int an = findind(max, carbs);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = carbs.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(carbs, ans);
                                    if (countC[max] == 1)
                                    {
                                        int an = findind(max, carbs);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = carbs.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }

                        }
                        else if (x[i] == 'f')
                        {

                            if (i == 0)
                            {

                                flag = 0;
                                int ind = minimum(fat);
                                if (countF[ind] == 1)
                                {

                                    int an = findind(ind, fat);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = fat.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(fat, ans);
                                    if (countF[max] == 1)
                                    {
                                        int an = findind(max, fat);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(fat, ans);
                                    if (countF[max] == 1)
                                    {
                                        int an = findind(max, fat);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }

                        }
                        else if (x[i] == 't')
                        {

                            if (i == 0)
                            {

                                flag = 0;
                                int ind = minimum(totalcalories);
                                if (countT[ind] == 1)
                                {
                                    int an = findind(ind, totalcalories);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = totalcalories.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();

                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(totalcalories, ans);
                                    if (countT[max] == 1)
                                    {
                                        int an = findind(max, totalcalories);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = totalcalories.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(totalcalories, ans);
                                    if (countT[max] == 1)
                                    {
                                        int an = findind(max, totalcalories);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = totalcalories.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }

                        }
                        else if (x[i] == 'p')
                        {

                            if (i == 0)
                            {

                                flag = 0;
                                int ind = minimum(protein);
                                if (countP[ind] == 1)
                                {
                                    int an = findind(ind, protein);
                                    a.Add(an);
                                    break;
                                }

                                else
                                {
                                    ans = protein.Select((b, j) => b == ind ? j : -1).Where(j => j != -1).ToArray();
                                    continue;

                                }
                            }
                            else
                            {
                                if (flag == 1)
                                {
                                    int max = findmax(protein, ans);
                                    if (countP[max] == 1)
                                    {
                                        int an = findind(max, protein);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = protein.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    int max = findmin(protein, ans);
                                    if (countP[max] == 1)
                                    {
                                        int an = findind(max, protein);
                                        a.Add(an);
                                        break;
                                    }
                                    else
                                    {
                                        if (count == x.Length - 1)
                                        {
                                            ans = fat.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            int an = ans.Min();
                                            a.Add(an);
                                            break;
                                        }
                                        else
                                        {
                                            ans = protein.Select((b, j) => b == max ? j : -1).Where(j => j != -1).ToArray();
                                            continue;
                                        }
                                    }
                                }
                            }

                        }

                    }
                }
              //  Console.WriteLine();

            }
            int[] ans1 = a.OfType<int>().ToArray();

            return ans1;
            throw new NotImplementedException();


        }


    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeacherComputerRetrieval_NewGlobe
{
    public partial class TestDistance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetRoutes.Text = "";
                GetAcademies.Text = "";
                maxStops.Text = "";
                GetStartEndAcademy.Text = "";
                GetAcademyDetails.Text = "";
                inputMaxDistance.Text = "";
            }
        }

        public static Dictionary<string, int> distance = newDict.GetDistance();
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GetRoutes.Text != "")
            {
                int totalDistance = 0;
                string inputDistance = GetRoutes.Text.ToUpper();
                int inputValueLength = inputDistance.Length;
                string result = string.Join<char>(",", inputDistance) + ",";
                string[] letters = result.Split(',');

                totalDistance = TotalDistance.CalculateDistance(distance, inputValueLength, letters);
                if (totalDistance != 0)
                {
                    GetResult.Text = "The Total Distance is " + Convert.ToString(totalDistance);
                }
                else
                {
                    GetResult.Text = "No Such Route available";
                }
            }
            else
            {
                GetResult.Text = "Please Enter Routes";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GetAcademies.Text != "" && maxStops.Text != "")
            {
                string inputRoutes = GetAcademies.Text.ToUpper();
                Console.WriteLine("Enter Maximum number of stops: ");
                int inputStops = Convert.ToInt32(maxStops.Text);

                string Routes = string.Join<char>(",", inputRoutes) + ",";
                string[] SeperateRoutes = Routes.Split(',');

                var newFirstFilteredRoutes = new Dictionary<string, int>();
                var newSecondFilteredRoutes = new Dictionary<string, int>();
                var newFirstFilteredRoutesForLoop = new Dictionary<string, int>();

                int numberOfStops = 0, newCountForSecondRoutes = 0, newCountForFirstRoutes = 0;

                foreach (KeyValuePair<string, int> DistanceValue in distance)
                {
                    if (Convert.ToString(DistanceValue.Key.FirstOrDefault()) == SeperateRoutes[0])
                    {
                        newFirstFilteredRoutes.Add(DistanceValue.Key, newCountForFirstRoutes++);
                    }
                    if (Convert.ToString(DistanceValue.Key.LastOrDefault()) == SeperateRoutes[1])
                    {
                        newSecondFilteredRoutes.Add(DistanceValue.Key, newCountForSecondRoutes++);
                    }

                }

                if (newFirstFilteredRoutes.Count > 0 && newSecondFilteredRoutes.Count > 0)
                {
                    foreach (KeyValuePair<string, int> DistanceValue in newFirstFilteredRoutes)
                    {
                        numberOfStops = 0;
                        string FirstKey = DistanceValue.Key;
                        string FixFirstKey = FirstKey;
                        numberOfStops++;

                        loop.distanceMeasure(FirstKey, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                    }
                    if (newFirstFilteredRoutesForLoop.Count > 0)
                    {
                        GetTotalRoutes.Text = "Total Routes based on stops are " + Convert.ToString(newFirstFilteredRoutesForLoop.Count);
                    }
                    else
                    {
                        GetTotalRoutes.Text = "No Routes available for the given stops";
                    }
                }
                else
                {
                    GetTotalRoutes.Text = "No Routes available for the given academy";
                }
            }
            else if (GetAcademies.Text == "" && GetAcademies.Text == "")
            {
                GetTotalRoutes.Text = "Please enter start and end academy and max stops";
            }
            else if (GetAcademies.Text == "")
            {
                GetTotalRoutes.Text = "Please enter start and end academy";
            }
            else
            {
                GetTotalRoutes.Text = "Please enter max stops";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GetStartEndAcademy.Text != "")
            {
                string userInputAcademics = GetStartEndAcademy.Text.ToUpper();
                string splittedAcademy = string.Join<char>(",", userInputAcademics) + ",";
                string[] SeperateAcademy = splittedAcademy.Split(',');

                var newFirstFilteredAcademy = new Dictionary<string, int>();
                var newSecondFilteredAcademy = new Dictionary<string, int>();

                foreach (KeyValuePair<string, int> DistanceValue in distance)
                {
                    if (Convert.ToString(DistanceValue.Key.FirstOrDefault()) == SeperateAcademy[0])
                    {
                        newFirstFilteredAcademy.Add(DistanceValue.Key, DistanceValue.Value);
                    }
                    if (Convert.ToString(DistanceValue.Key.LastOrDefault()) == SeperateAcademy[1])
                    {
                        newSecondFilteredAcademy.Add(DistanceValue.Key, DistanceValue.Value);
                    }

                }

                int totalDistance = 0, newTotalDistance = 0, count = 0;

                if (newFirstFilteredAcademy.Count > 0 && newSecondFilteredAcademy.Count > 0)
                {
                    foreach (KeyValuePair<string, int> firstDistanceKey in newFirstFilteredAcademy)
                    {
                        foreach (KeyValuePair<string, int> secondDistanceKey in newSecondFilteredAcademy)
                        {
                            count++;
                            if (firstDistanceKey.Key == secondDistanceKey.Key)
                            {
                                totalDistance = firstDistanceKey.Value;
                            }
                            else if (firstDistanceKey.Key.LastOrDefault() == secondDistanceKey.Key.FirstOrDefault())
                            {
                                if (totalDistance == 0)
                                {
                                    totalDistance = firstDistanceKey.Value + secondDistanceKey.Value;
                                }
                                else
                                {
                                    newTotalDistance = firstDistanceKey.Value + secondDistanceKey.Value;
                                }

                            }
                            else if (count == newSecondFilteredAcademy.Count)
                            {
                                foreach (KeyValuePair<string, int> seperateDistanceValue in distance)
                                {
                                    if (firstDistanceKey.Key.LastOrDefault() == seperateDistanceValue.Key.FirstOrDefault())
                                    {
                                        foreach (KeyValuePair<string, int> separateSecondDistanceKey in newSecondFilteredAcademy)
                                        {
                                            if (seperateDistanceValue.Key.LastOrDefault() == separateSecondDistanceKey.Key.FirstOrDefault())
                                            {
                                                if (totalDistance == 0)
                                                {
                                                    totalDistance = firstDistanceKey.Value + seperateDistanceValue.Value + separateSecondDistanceKey.Value;
                                                }
                                                else
                                                {
                                                    newTotalDistance = firstDistanceKey.Value + seperateDistanceValue.Value + separateSecondDistanceKey.Value;

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (totalDistance > 0 && newTotalDistance > 0)
                    {
                        if (totalDistance < newTotalDistance)
                        {
                            GetShortestRouteDistance.Text = "Shortest route in terms of distance is " + Convert.ToString(totalDistance);
                        }
                        else
                        {
                            GetShortestRouteDistance.Text = "Shortest route in terms of distance is " + Convert.ToString(newTotalDistance);
                        }

                    }
                    else if (newTotalDistance == 0)
                    {
                        GetShortestRouteDistance.Text = "Shortest route in terms of distance is " + Convert.ToString(totalDistance);
                    }

                }
                else if (newFirstFilteredAcademy.Count > 0 && newSecondFilteredAcademy.Count == 0)
                {
                    GetShortestRouteDistance.Text = "End academy doesn't exists";
                }
                else if (newFirstFilteredAcademy.Count == 0 && newSecondFilteredAcademy.Count > 0)
                {
                    GetShortestRouteDistance.Text = "Start academy doesn't exists";
                }
                else
                {
                    GetShortestRouteDistance.Text = "Given academies doesn't exists";
                }
            }
            else
            {
                GetShortestRouteDistance.Text = "Please enter start and end academy";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (GetAcademyDetails.Text != "" && inputMaxDistance.Text != "")
            {
                string getAcademics = GetAcademyDetails.Text.ToUpper();
                Console.WriteLine("Enter the Max distance to get number of routes");
                int maxDistance = Convert.ToInt32(inputMaxDistance.Text);

                string splittedAcademy = string.Join<char>(",", getAcademics) + ",";
                string[] SeperateAcademy = splittedAcademy.Split(',');

                var newFirstFilteredAcademy = new Dictionary<string, int>();
                var newSecondFilteredAcademy = new Dictionary<string, int>();
                var newFinalFilteredAcademy = new Dictionary<string, int>();


                foreach (KeyValuePair<string, int> DistanceValue in distance)
                {
                    if (Convert.ToString(DistanceValue.Key.FirstOrDefault()) == SeperateAcademy[0])
                    {
                        newFirstFilteredAcademy.Add(DistanceValue.Key, DistanceValue.Value);
                    }
                    if (Convert.ToString(DistanceValue.Key.LastOrDefault()) == SeperateAcademy[1])
                    {
                        newSecondFilteredAcademy.Add(DistanceValue.Key, DistanceValue.Value);
                    }
                }

                if (newFirstFilteredAcademy.Count > 0 && newSecondFilteredAcademy.Count > 0)
                {
                    int totalDistance = 0;
                    if (totalDistance < maxDistance)
                    {
                        foreach (KeyValuePair<string, int> firstDistanceKey in newFirstFilteredAcademy)
                        {
                            int numberOfRoutes = 0;
                            string FirstKey = firstDistanceKey.Key;
                            int FirstKeyValue = firstDistanceKey.Value;
                            string firstFixKey = FirstKey;
                            int firstFixKeyValue = FirstKeyValue;
                            numberOfRoutesBasedOnDistance.routesBasedOnDistance(distance, newFirstFilteredAcademy,
                                newSecondFilteredAcademy, SeperateAcademy, maxDistance, FirstKey, FirstKeyValue, newFinalFilteredAcademy,
                                firstFixKey, firstFixKeyValue, numberOfRoutes, totalDistance);
                        }
                    }
                }
                GetTotalRoutesBasedOnDistance.Text = "Total Routes based on given distance are: " + Convert.ToString(newFinalFilteredAcademy.Count);
            }
            else if (GetAcademyDetails.Text == "")
            {
                GetTotalRoutesBasedOnDistance.Text = "Please enter start and end academy";
            }
            else if (inputMaxDistance.Text == "")
            {
                GetTotalRoutesBasedOnDistance.Text = "Please enter distance";
            }
            else
            {
                GetTotalRoutesBasedOnDistance.Text = "Please enter start and end academy and distance";
            }
        }

        protected void Result1_TextChanged(object sender, EventArgs e)
        {
            if (GetRoutes.Text == "")
            {
                GetResult.Visible = false;
           }
        }
        
        protected void Result2_TextChanged(object sender, EventArgs e)
        {
            if (GetAcademies.Text == "")
            {
                maxStops.Text = "";
                GetTotalRoutes.Visible = false;
            }
        }
        
        protected void Result3_TextChanged(object sender, EventArgs e)
        {
            if (GetStartEndAcademy.Text == "")
            {
                GetShortestRouteDistance.Visible = false;
            }
        }
        
        protected void Result4_TextChanged(object sender, EventArgs e)
        {
            if (GetAcademyDetails.Text == "")
            {
                inputMaxDistance.Text = "";
                GetTotalRoutesBasedOnDistance.Visible = false;
            }
        }
        
    }

    public class newDict
    {
        public static Dictionary<string, int> GetDistance()
        {
            Dictionary<string, int> distance = new Dictionary<string, int>();
            distance.Add("AB", 5);
            distance.Add("BC", 4);
            distance.Add("CD", 8);
            distance.Add("DC", 8);
            distance.Add("AD", 5);
            distance.Add("DE", 6);
            distance.Add("CE", 2);
            distance.Add("EB", 3);
            distance.Add("AE", 7);
            return distance;
        }
    }
    public class TotalDistance
    {
        public static int CalculateDistance(Dictionary<string, int> distance, int inputValueLength, string[] letters)
        {
            string letterCombo = "", output = "";
            int totalDistance = 0;

            for (int i = 0; i < inputValueLength; i++)
            {
                if (output != "No Such Route")
                {
                    letterCombo = letterCombo + letters[i];
                    if (letterCombo.Length == 2)
                    {
                        foreach (KeyValuePair<string, int> DistanceValue in distance)
                        {
                            if (distance.ContainsKey(letterCombo))
                            {
                                if (letterCombo.Contains(DistanceValue.Key))
                                {
                                    totalDistance = totalDistance + DistanceValue.Value;
                                }
                            }
                            else
                            {
                                output = "No Such Route";
                                totalDistance = 0;
                                break;
                            }
                        }
                        letterCombo = "";
                        i--;
                    }
                }
                else
                {
                    break;
                }
            }
            return totalDistance;
        }
    }

    public class loop
    {
        public static void distanceMeasure(string FirstKey, Dictionary<string, int> distance, string[] SeperateRoutes,
            int numberOfStops, int inputStops, Dictionary<string, int> newFirstFilteredRoutesForLoop, Dictionary<string, int> newSecondFilteredRoutes, string FixFirstKey)
        {
            string NewFirstKey = "";
            bool checkValue = false;
            foreach (KeyValuePair<string, int> NewDistanceValue in distance.ToList())
            {
                if (FirstKey.LastOrDefault() == NewDistanceValue.Key.FirstOrDefault())
                {
                    NewFirstKey = NewDistanceValue.Key;

                    if (newFirstFilteredRoutesForLoop.Count > 0)
                    {
                        foreach (string key in newFirstFilteredRoutesForLoop.Keys.ToList())
                        {
                            if (key.StartsWith(FirstKey + NewFirstKey))
                            {
                                checkValue = true;
                                break;
                            }
                            else
                            {
                                checkValue = false;
                            }
                        }
                    }

                    if (checkValue == false)
                    {
                        numberOfStops++;
                        if (Convert.ToString(NewFirstKey.LastOrDefault()) == SeperateRoutes[1])
                        {
                            if (SeperateRoutes[0] == "C" && SeperateRoutes[1] == "C")
                            {
                                if (numberOfStops <= inputStops)
                                {
                                    if (FixFirstKey == FirstKey)
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    else
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else if (numberOfStops > inputStops)
                                {
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else
                                {
                                    distanceMeasure(NewFirstKey, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                }
                            }
                            else if (SeperateRoutes[0] == "A" && SeperateRoutes[1] == "C")
                            {
                                if (numberOfStops <= inputStops)
                                {
                                    distanceMeasure(NewFirstKey, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                    if (newFirstFilteredRoutesForLoop.Count > 0)
                                    {
                                        foreach (string key in newFirstFilteredRoutesForLoop.Keys.ToList())
                                        {
                                            if (key.StartsWith(FirstKey + NewFirstKey))
                                            {
                                                numberOfStops = 1;
                                            }
                                        }
                                    }

                                }
                                else if (numberOfStops == inputStops)
                                {
                                    if (FixFirstKey == FirstKey)
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    else
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else if (numberOfStops > inputStops)
                                {
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else
                                {
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                            }
                            else
                            {

                                if (numberOfStops <= inputStops)
                                {
                                    if (FixFirstKey == FirstKey)
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    else
                                    {
                                        newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey, numberOfStops);
                                    }
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else if (numberOfStops > inputStops)
                                {
                                    FirstKey = FixFirstKey;
                                    break;
                                }
                                else
                                {
                                    distanceMeasure(NewFirstKey, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                }
                            }

                        }
                        else
                        {
                            int valueOfCount = 0;
                            foreach (KeyValuePair<string, int> secondFilteredRoutes in newSecondFilteredRoutes)
                            {
                                valueOfCount++;
                                if (NewFirstKey.LastOrDefault() == secondFilteredRoutes.Key.FirstOrDefault())
                                {
                                    numberOfStops++;
                                    if (Convert.ToString(secondFilteredRoutes.Key.LastOrDefault()) == SeperateRoutes[1])
                                    {
                                        if (SeperateRoutes[0] == "C" && SeperateRoutes[1] == "C")
                                        {
                                            if (numberOfStops <= inputStops)
                                            {
                                                if (FixFirstKey == FirstKey)
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }
                                                else
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }
                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                            else if (numberOfStops > inputStops)
                                            {
                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                            else
                                            {
                                                distanceMeasure(secondFilteredRoutes.Key, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                            }
                                        }
                                        else if (SeperateRoutes[0] == "A" && SeperateRoutes[1] == "C")
                                        {
                                            if (inputStops != numberOfStops && numberOfStops <= inputStops)
                                            {
                                                distanceMeasure(secondFilteredRoutes.Key, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                            }
                                            else if (numberOfStops == inputStops)
                                            {
                                                if (FixFirstKey == FirstKey)
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }
                                                else
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }

                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                            else
                                            {
                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (numberOfStops <= inputStops)
                                            {
                                                if (FixFirstKey == FirstKey)
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }
                                                else
                                                {
                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + secondFilteredRoutes.Key, numberOfStops);
                                                }
                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                            else if (numberOfStops > inputStops)
                                            {
                                                FirstKey = FixFirstKey;
                                                break;
                                            }
                                            else
                                            {
                                                distanceMeasure(secondFilteredRoutes.Key, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                            }
                                        }
                                    }
                                }
                                else if (valueOfCount == newSecondFilteredRoutes.Count)
                                {
                                    foreach (KeyValuePair<string, int> DistanceValueForRoutes in distance)
                                    {
                                        if (NewFirstKey.LastOrDefault() == DistanceValueForRoutes.Key.FirstOrDefault())
                                        {
                                            numberOfStops++;

                                            foreach (KeyValuePair<string, int> newsecondFilteredRoutes in newSecondFilteredRoutes)
                                            {
                                                if (DistanceValueForRoutes.Key.LastOrDefault() == newsecondFilteredRoutes.Key.FirstOrDefault())
                                                {
                                                    numberOfStops++;

                                                    if (Convert.ToString(newsecondFilteredRoutes.Key.LastOrDefault()) == SeperateRoutes[1])
                                                    {
                                                        if (SeperateRoutes[0] == "C" && SeperateRoutes[1] == "C")
                                                        {
                                                            if (numberOfStops <= inputStops)
                                                            {
                                                                if (FixFirstKey == FirstKey)
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }
                                                                else
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }

                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                            else if (numberOfStops > inputStops)
                                                            {
                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                distanceMeasure(newsecondFilteredRoutes.Key, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                                            }
                                                        }
                                                        else if (SeperateRoutes[0] == "A" && SeperateRoutes[1] == "C")
                                                        {

                                                            if (inputStops != numberOfStops && numberOfStops <= inputStops)
                                                            {
                                                                distanceMeasure(NewFirstKey, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                                            }
                                                            else if (numberOfStops == inputStops)
                                                            {
                                                                if (FixFirstKey == FirstKey)
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + DistanceValueForRoutes.Key + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }
                                                                else
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + DistanceValueForRoutes.Key + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }

                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                            else
                                                            {

                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (numberOfStops <= inputStops)
                                                            {
                                                                if (FixFirstKey == FirstKey)
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FirstKey + NewFirstKey + DistanceValueForRoutes.Key + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }
                                                                else
                                                                {
                                                                    newFirstFilteredRoutesForLoop.Add(FixFirstKey + FirstKey + NewFirstKey + DistanceValueForRoutes.Key + newsecondFilteredRoutes.Key, numberOfStops);
                                                                }
                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                            else if (numberOfStops > inputStops)
                                                            {
                                                                FirstKey = FixFirstKey;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                distanceMeasure(newsecondFilteredRoutes.Key, distance, SeperateRoutes, numberOfStops, inputStops, newFirstFilteredRoutesForLoop, newSecondFilteredRoutes, FixFirstKey);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public class numberOfRoutesBasedOnDistance
    {
        public static void routesBasedOnDistance(Dictionary<string, int> distance, Dictionary<string, int> newFirstFilteredAcademy,
            Dictionary<string, int> newSecondFilteredAcademy, string[] SeperateAcademy, int maxDistance, string FirstKey, int FirstKeyValue,
            Dictionary<string, int> newFinalFilteredAcademy, string firstFixKey, int firstFixKeyValue, int numberOfRoutes, int totalDistance)
        {
            string newKey = "";


            foreach (KeyValuePair<string, int> originalDistanceKey in distance)
            {
                if (FirstKey.LastOrDefault() == originalDistanceKey.Key.FirstOrDefault())
                {
                    if (totalDistance > maxDistance)
                    {
                        totalDistance = 0;
                    }
                    if (Convert.ToString(originalDistanceKey.Key.LastOrDefault()) == SeperateAcademy[1])
                    {
                        if (FirstKey == firstFixKey)
                        {
                            totalDistance = FirstKeyValue + originalDistanceKey.Value;
                            for (int i = 1; totalDistance * i < maxDistance; i++)
                            {
                                numberOfRoutes++;
                                if (!newFinalFilteredAcademy.ContainsKey(FirstKey + originalDistanceKey.Key))
                                {
                                    newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(FirstKey + originalDistanceKey.Key, i)), numberOfRoutes);
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            totalDistance = FirstKeyValue + firstFixKeyValue + originalDistanceKey.Value;
                            for (int i = 1; totalDistance * i < maxDistance; i++)
                            {
                                numberOfRoutes++;
                                if (!newFinalFilteredAcademy.ContainsKey(firstFixKey + FirstKey + originalDistanceKey.Key))
                                {
                                    newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(firstFixKey + FirstKey + originalDistanceKey.Key, i)), numberOfRoutes);
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        if (totalDistance < maxDistance)
                        {
                            FirstKey = originalDistanceKey.Key;
                            FirstKeyValue = originalDistanceKey.Value;
                            routesBasedOnDistance(distance, newFirstFilteredAcademy, newSecondFilteredAcademy, SeperateAcademy, maxDistance, FirstKey, FirstKeyValue,
                                newFinalFilteredAcademy, firstFixKey, firstFixKeyValue, numberOfRoutes, totalDistance);
                            FirstKey = firstFixKey;
                            FirstKeyValue = firstFixKeyValue;
                            totalDistance = 0;
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> secondDistanceKey in newSecondFilteredAcademy)
                        {
                            if (originalDistanceKey.Key.LastOrDefault() == secondDistanceKey.Key.FirstOrDefault())
                            {
                                if (FirstKey == firstFixKey)
                                {
                                    totalDistance = FirstKeyValue + originalDistanceKey.Value + secondDistanceKey.Value;
                                    if (!newFinalFilteredAcademy.ContainsKey(FirstKey + originalDistanceKey.Key + secondDistanceKey.Key))
                                    {
                                        for (int i = 1; totalDistance * i < maxDistance; i++)
                                        {
                                            numberOfRoutes++;
                                            newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(FirstKey + originalDistanceKey.Key + secondDistanceKey.Key, i)), numberOfRoutes);
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    totalDistance = FirstKeyValue + firstFixKeyValue + originalDistanceKey.Value + secondDistanceKey.Value;
                                    for (int i = 1; totalDistance * i < maxDistance; i++)
                                    {
                                        numberOfRoutes++;
                                        if (!newFinalFilteredAcademy.ContainsKey(firstFixKey + FirstKey + originalDistanceKey.Key + secondDistanceKey.Key))
                                        {
                                            newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(firstFixKey + FirstKey + originalDistanceKey.Key + secondDistanceKey.Key, i)), numberOfRoutes);
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                }
                                if (totalDistance < maxDistance)
                                {
                                    FirstKey = originalDistanceKey.Key + secondDistanceKey.Key;
                                    FirstKeyValue = originalDistanceKey.Value + secondDistanceKey.Value;
                                    routesBasedOnDistance(distance, newFirstFilteredAcademy, newSecondFilteredAcademy, SeperateAcademy, maxDistance, FirstKey, FirstKeyValue,
                                        newFinalFilteredAcademy, firstFixKey, firstFixKeyValue, numberOfRoutes, totalDistance);
                                    FirstKey = firstFixKey;
                                    FirstKeyValue = firstFixKeyValue;
                                }
                            }
                            else
                            {
                                string splittedFirstRoute = string.Join<char>(",", originalDistanceKey.Key) + ",";
                                string[] SeperatefirstRoute = splittedFirstRoute.Split(',');

                                string splittedSecondRoute = string.Join<char>(",", secondDistanceKey.Key) + ",";
                                string[] SeperateSecondRoute = splittedSecondRoute.Split(',');


                                newKey = SeperatefirstRoute[1] + SeperateSecondRoute[0];
                                if (distance.ContainsKey(newKey))
                                {
                                    foreach (KeyValuePair<string, int> finalDistanceKey in distance)
                                    {
                                        if (newKey == finalDistanceKey.Key)
                                        {
                                            if (FirstKey == firstFixKey)
                                            {
                                                totalDistance = FirstKeyValue + originalDistanceKey.Value + finalDistanceKey.Value + secondDistanceKey.Value;
                                                for (int i = 1; totalDistance * i < maxDistance; i++)
                                                {
                                                    numberOfRoutes++;
                                                    if (!newFinalFilteredAcademy.ContainsKey(FirstKey + originalDistanceKey.Key + finalDistanceKey.Key + secondDistanceKey.Key))
                                                    {
                                                        newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(FirstKey + originalDistanceKey.Key + finalDistanceKey.Key
                                                        + secondDistanceKey.Key, i)), numberOfRoutes);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (totalDistance > 0 && totalDistance < maxDistance)
                                                {
                                                    totalDistance += FirstKeyValue + firstFixKeyValue + originalDistanceKey.Value + finalDistanceKey.Value + secondDistanceKey.Value - FirstKeyValue;
                                                }
                                                else
                                                {
                                                    totalDistance = FirstKeyValue + firstFixKeyValue + originalDistanceKey.Value + finalDistanceKey.Value + secondDistanceKey.Value;
                                                }
                                                for (int i = 1; totalDistance * i < maxDistance; i++)
                                                {
                                                    numberOfRoutes++;
                                                    if (firstFixKey == originalDistanceKey.Key)
                                                    {
                                                        if (!newFinalFilteredAcademy.ContainsKey(FirstKey + originalDistanceKey.Key +
                                                        finalDistanceKey.Key + secondDistanceKey.Key))
                                                        {
                                                            newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(FirstKey + originalDistanceKey.Key +
                                                            finalDistanceKey.Key + secondDistanceKey.Key, i)), numberOfRoutes);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (!newFinalFilteredAcademy.ContainsKey(firstFixKey + FirstKey + originalDistanceKey.Key +
                                                        finalDistanceKey.Key + secondDistanceKey.Key))
                                                        {
                                                            newFinalFilteredAcademy.Add(String.Concat(Enumerable.Repeat(firstFixKey + FirstKey + originalDistanceKey.Key +
                                                            finalDistanceKey.Key + secondDistanceKey.Key, i)), numberOfRoutes);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
    

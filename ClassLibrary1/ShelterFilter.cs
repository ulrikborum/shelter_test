using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;

public class ShelterFilter
{
    public List<Shelter> FilterByPlace(List<Shelter> shelters, string place)
    {
        List<Shelter> result = new List<Shelter>();

        foreach (Shelter shelter in shelters) 
        {
            if (shelter.Place == place)
            {
                result.Add(shelter);
            }
        }

        return result;
    }
}
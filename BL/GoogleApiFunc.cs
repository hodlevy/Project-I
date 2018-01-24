﻿using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;

namespace BL
{
    public enum TravelType
    {
        Walking,
        Driving
    }
    public class GoogleApiFunc
    {
        //static string API_KEY = "AIzaSyAELI--sxpTYDbvHQHUBCV76MovfOVM75g";

        public static List<string> GetPlaceAutoComplete(string str)
        {
            //List<string> result = new List<string>();
            //GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest();
            //request.ApiKey = API_KEY;
            //request.Input = str;

            //var response = GoogleMaps.PlaceAutocomplete.Query(request);

            //foreach (var item in response.Results)
            //{
            //    result.Add(item.Description);
            //}

            //return result;
            List<string> result = new List<string>();
            PlaceAutocompleteRequest request = new PlaceAutocompleteRequest();
            request.ApiKey = "AIzaSyAELI--sxpTYDbvHQHUBCV76MovfOVM75g";
            request.Input = str;
            var response = GoogleMaps.PlaceAutocomplete.Query(request);
            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }
            return result;
        }
        public static int CalcDistance(string source, string dest, TravelType travelType)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = travelType == TravelType.Walking ? TravelMode.Walking : TravelMode.Driving,
                    Origin = source,
                    Destination = dest,

                };


                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static TimeSpan CalcDuration(string source, string dest, TravelType travelType)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = travelType == TravelType.Walking ? TravelMode.Walking : TravelMode.Driving,
                    Origin = source,
                    Destination = dest,
                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Duration.Value;
            }
            catch (Exception)
            {
                return default(TimeSpan);
            }
        }
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };

            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
    }
}

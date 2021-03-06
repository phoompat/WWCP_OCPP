﻿/*
 * Copyright (c) 2014-2020 GraphDefined GmbH
 * This file is part of WWCP OCPP <https://github.com/OpenChargingCloud/WWCP_OCPP>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Xml.Linq;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Hermod.JSON;

#endregion

namespace cloud.charging.adapters.OCPPv1_6.CS
{

    /// <summary>
    /// A get diagnostics request.
    /// </summary>
    public class GetDiagnosticsRequest : ARequest<GetDiagnosticsRequest>
    {

        #region Properties

        /// <summary>
        /// The URI where the diagnostics file shall be uploaded to.
        /// </summary>
        public String     Location         { get; }

        /// <summary>
        /// The timestamp of the oldest logging information to include in
        /// the diagnostics.
        /// </summary>
        public DateTime?  StartTime        { get; }

        /// <summary>
        /// The timestamp of the latest logging information to include in
        /// the diagnostics.
        /// </summary>
        public DateTime?  StopTime         { get; }

        /// <summary>
        /// The optional number of retries of a charge point for trying to
        /// upload the diagnostics before giving up. If this field is not
        /// present, it is left to the charge point to decide how many times
        /// it wants to retry.
        /// </summary>
        public Byte?      Retries          { get; }

        /// <summary>
        /// The interval after which a retry may be attempted. If this field
        /// is not present, it is left to charge point to decide how long to
        /// wait between attempts.
        /// </summary>
        public TimeSpan?  RetryInterval    { get; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a GetDiagnostics request.
        /// </summary>
        /// <param name="Location">The URI where the diagnostics file shall be uploaded to.</param>
        /// <param name="StartTime">The timestamp of the oldest logging information to include in the diagnostics.</param>
        /// <param name="StopTime">The timestamp of the latest logging information to include in the diagnostics.</param>
        /// <param name="Retries">The optional number of retries of a charge point for trying to upload the diagnostics before giving up. If this field is not present, it is left to the charge point to decide how many times it wants to retry.</param>
        /// <param name="RetryInterval">The interval after which a retry may be attempted. If this field is not present, it is left to charge point to decide how long to wait between attempts.</param>
        public GetDiagnosticsRequest(String     Location,
                                     DateTime?  StartTime       = null,
                                     DateTime?  StopTime        = null,
                                     Byte?      Retries         = null,
                                     TimeSpan?  RetryInterval   = null)
        {

            #region Initial checks

            Location = Location?.Trim();

            if (Location.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(Location),  "The given location must not be null or empty!");

            #endregion

            this.Location       = Location;
            this.StartTime      = StartTime;
            this.StopTime       = StopTime;
            this.Retries        = Retries;
            this.RetryInterval  = RetryInterval;

        }

        #endregion


        #region Documentation

        // <soap:Envelope xmlns:soap = "http://www.w3.org/2003/05/soap-envelope"
        //                xmlns:wsa  = "http://www.w3.org/2005/08/addressing"
        //                xmlns:ns   = "urn://Ocpp/Cp/2015/10/">
        //
        //    <soap:Header>
        //       ...
        //    </soap:Header>
        //
        //    <soap:Body>
        //       <ns:getDiagnosticsRequest>
        //
        //          <ns:location>?</ns:location>
        //
        //          <!--Optional:-->
        //          <ns:startTime>?</ns:startTime>
        //
        //          <!--Optional:-->
        //          <ns:stopTime>?</ns:stopTime>
        //
        //          <!--Optional:-->
        //          <ns:retries>?</ns:retries>
        //
        //          <!--Optional:-->
        //          <ns:retryInterval>?</ns:retryInterval>
        //
        //       </ns:getDiagnosticsRequest>
        //    </soap:Body>
        //
        // </soap:Envelope>

        // {
        //     "$schema": "http://json-schema.org/draft-04/schema#",
        //     "id":      "urn:OCPP:1.6:2019:12:GetDiagnosticsRequest",
        //     "title":   "GetDiagnosticsRequest",
        //     "type":    "object",
        //     "properties": {
        //         "location": {
        //             "type": "string",
        //             "format": "uri"
        //         },
        //         "retries": {
        //             "type": "integer"
        //         },
        //         "retryInterval": {
        //             "type": "integer"
        //         },
        //         "startTime": {
        //             "type": "string",
        //             "format": "date-time"
        //         },
        //         "stopTime": {
        //             "type": "string",
        //             "format": "date-time"
        //         }
        //     },
        //     "additionalProperties": false,
        //     "required": [
        //         "location"
        //     ]
        // }

        #endregion

        #region (static) Parse   (GetDiagnosticsRequestXML,  OnException = null)

        /// <summary>
        /// Parse the given XML representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestXML">The XML to be parsed.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static GetDiagnosticsRequest Parse(XElement             GetDiagnosticsRequestXML,
                                                  OnExceptionDelegate  OnException = null)
        {

            if (TryParse(GetDiagnosticsRequestXML,
                         out GetDiagnosticsRequest getDiagnosticsRequest,
                         OnException))
            {
                return getDiagnosticsRequest;
            }

            return null;

        }

        #endregion

        #region (static) Parse   (GetDiagnosticsRequestJSON, OnException = null)

        /// <summary>
        /// Parse the given JSON representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestJSON">The JSON to be parsed.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static GetDiagnosticsRequest Parse(JObject              GetDiagnosticsRequestJSON,
                                                  OnExceptionDelegate  OnException = null)
        {

            if (TryParse(GetDiagnosticsRequestJSON,
                         out GetDiagnosticsRequest getDiagnosticsRequest,
                         OnException))
            {
                return getDiagnosticsRequest;
            }

            return null;

        }

        #endregion

        #region (static) Parse   (GetDiagnosticsRequestText, OnException = null)

        /// <summary>
        /// Parse the given text representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestText">The text to be parsed.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static GetDiagnosticsRequest Parse(String               GetDiagnosticsRequestText,
                                                  OnExceptionDelegate  OnException = null)
        {

            if (TryParse(GetDiagnosticsRequestText,
                         out GetDiagnosticsRequest getDiagnosticsRequest,
                         OnException))
            {
                return getDiagnosticsRequest;
            }

            return null;

        }

        #endregion

        #region (static) TryParse(GetDiagnosticsRequestXML,  out GetDiagnosticsRequest, OnException = null)

        /// <summary>
        /// Try to parse the given XML representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestXML">The XML to be parsed.</param>
        /// <param name="GetDiagnosticsRequest">The parsed get diagnostics request.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(XElement                   GetDiagnosticsRequestXML,
                                       out GetDiagnosticsRequest  GetDiagnosticsRequest,
                                       OnExceptionDelegate        OnException  = null)
        {

            try
            {

                GetDiagnosticsRequest = new GetDiagnosticsRequest(

                                            GetDiagnosticsRequestXML.ElementValueOrFail(OCPPNS.OCPPv1_6_CP + "location"),

                                            GetDiagnosticsRequestXML.MapValueOrNullable(OCPPNS.OCPPv1_6_CP + "startTime",
                                                                                        DateTime.Parse),

                                            GetDiagnosticsRequestXML.MapValueOrNullable(OCPPNS.OCPPv1_6_CP + "stopTime",
                                                                                        DateTime.Parse),

                                            GetDiagnosticsRequestXML.MapValueOrNullable(OCPPNS.OCPPv1_6_CP + "retries",
                                                                                        Byte.Parse),

                                            GetDiagnosticsRequestXML.MapValueOrNullable(OCPPNS.OCPPv1_6_CP + "retryInterval",
                                                                                        s => TimeSpan.FromSeconds(UInt32.Parse(s)))

                                        );

                return true;

            }
            catch (Exception e)
            {

                OnException?.Invoke(DateTime.UtcNow, GetDiagnosticsRequestXML, e);

                GetDiagnosticsRequest = null;
                return false;

            }

        }

        #endregion

        #region (static) TryParse(GetDiagnosticsRequestJSON, out GetDiagnosticsRequest, OnException = null)

        /// <summary>
        /// Try to parse the given JSON representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestJSON">The JSON to be parsed.</param>
        /// <param name="GetDiagnosticsRequest">The parsed get diagnostics request.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(JObject                    GetDiagnosticsRequestJSON,
                                       out GetDiagnosticsRequest  GetDiagnosticsRequest,
                                       OnExceptionDelegate        OnException  = null)
        {

            try
            {

                GetDiagnosticsRequest = null;

                #region Location

                var Location = GetDiagnosticsRequestJSON.GetString("location");

                #endregion

                #region StartTime

                if (GetDiagnosticsRequestJSON.ParseOptional("startTime",
                                                            "start time",
                                                            out DateTime?  StartTime,
                                                            out String     ErrorResponse))
                {

                    if (ErrorResponse != null)
                        return false;

                }

                #endregion

                #region StopTime

                if (GetDiagnosticsRequestJSON.ParseOptional("stopTime",
                                                            "stop time",
                                                            out DateTime?  StopTime,
                                                            out            ErrorResponse))
                {

                    if (ErrorResponse != null)
                        return false;

                }

                #endregion

                #region Retries

                if (GetDiagnosticsRequestJSON.ParseOptional("retries",
                                                            "retries",
                                                            out Byte?  Retries,
                                                            out        ErrorResponse))
                {

                    if (ErrorResponse != null)
                        return false;

                }

                #endregion

                #region RetryInterval

                if (GetDiagnosticsRequestJSON.ParseOptional("retryInterval",
                                                            "retry interval",
                                                            out TimeSpan?  RetryInterval,
                                                            out            ErrorResponse))
                {

                    if (ErrorResponse != null)
                        return false;

                }

                #endregion


                GetDiagnosticsRequest = new GetDiagnosticsRequest(Location,
                                                                  StartTime,
                                                                  StopTime,
                                                                  Retries,
                                                                  RetryInterval);

                return true;

            }
            catch (Exception e)
            {

                OnException?.Invoke(DateTime.UtcNow, GetDiagnosticsRequestJSON, e);

                GetDiagnosticsRequest = null;
                return false;

            }

        }

        #endregion

        #region (static) TryParse(GetDiagnosticsRequestText, out GetDiagnosticsRequest, OnException = null)

        /// <summary>
        /// Try to parse the given text representation of a get diagnostics request.
        /// </summary>
        /// <param name="GetDiagnosticsRequestText">The text to be parsed.</param>
        /// <param name="GetDiagnosticsRequest">The parsed get diagnostics request.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(String                     GetDiagnosticsRequestText,
                                       out GetDiagnosticsRequest  GetDiagnosticsRequest,
                                       OnExceptionDelegate        OnException  = null)
        {

            try
            {

                GetDiagnosticsRequestText = GetDiagnosticsRequestText?.Trim();

                if (GetDiagnosticsRequestText.IsNotNullOrEmpty())
                {

                    if (GetDiagnosticsRequestText.StartsWith("{") &&
                        TryParse(JObject.Parse(GetDiagnosticsRequestText),
                                 out GetDiagnosticsRequest,
                                 OnException))
                    {
                        return true;
                    }

                    if (TryParse(XDocument.Parse(GetDiagnosticsRequestText).Root,
                                 out GetDiagnosticsRequest,
                                 OnException))
                    {
                        return true;
                    }

                }

            }
            catch (Exception e)
            {
                OnException?.Invoke(DateTime.UtcNow, GetDiagnosticsRequestText, e);
            }

            GetDiagnosticsRequest = null;
            return false;

        }

        #endregion

        #region ToXML()

        /// <summary>
        /// Return a XML representation of this object.
        /// </summary>
        public XElement ToXML()

            => new XElement(OCPPNS.OCPPv1_6_CP + "getDiagnosticsRequest",

                   new XElement(OCPPNS.OCPPv1_6_CP + "location",             Location),

                   StartTime.HasValue
                       ? new XElement(OCPPNS.OCPPv1_6_CP + "startTime",      StartTime.Value.ToIso8601())
                       : null,

                   StopTime.HasValue
                       ? new XElement(OCPPNS.OCPPv1_6_CP + "stopTime",       StopTime.Value.ToIso8601())
                       : null,

                   Retries.HasValue
                       ? new XElement(OCPPNS.OCPPv1_6_CP + "retries",        Retries.Value)
                       : null,

                   RetryInterval.HasValue
                       ? new XElement(OCPPNS.OCPPv1_6_CP + "retryInterval",  RetryInterval.Value.TotalSeconds)
                       : null

               );

        #endregion

        #region ToJSON(CustomGetDiagnosticsRequestSerializer = null)

        /// <summary>
        /// Return a JSON representation of this object.
        /// </summary>
        /// <param name="CustomGetDiagnosticsRequestSerializer">A delegate to serialize custom start transaction requests.</param>
        public JObject ToJSON(CustomJObjectSerializerDelegate<GetDiagnosticsRequest> CustomGetDiagnosticsRequestSerializer  = null)
        {

            var JSON = JSONObject.Create(

                           new JProperty("location",             Location),

                           StartTime.HasValue
                               ? new JProperty("startTime",      StartTime.Value.ToIso8601())
                               : null,

                           StopTime.HasValue
                               ? new JProperty("stopTime",       StopTime. Value.ToIso8601())
                               : null,

                           Retries.HasValue
                               ? new JProperty("retries",        Retries.  Value.ToString())
                               : null,

                           RetryInterval.HasValue
                               ? new JProperty("retryInterval",  (UInt64) RetryInterval.Value.TotalSeconds)
                               : null

                       );

            return CustomGetDiagnosticsRequestSerializer != null
                       ? CustomGetDiagnosticsRequestSerializer(this, JSON)
                       : JSON;

        }

        #endregion


        #region Operator overloading

        #region Operator == (GetDiagnosticsRequest1, GetDiagnosticsRequest2)

        /// <summary>
        /// Compares two get diagnostics requests for equality.
        /// </summary>
        /// <param name="GetDiagnosticsRequest1">A get diagnostics request.</param>
        /// <param name="GetDiagnosticsRequest2">Another get diagnostics request.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public static Boolean operator == (GetDiagnosticsRequest GetDiagnosticsRequest1, GetDiagnosticsRequest GetDiagnosticsRequest2)
        {

            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(GetDiagnosticsRequest1, GetDiagnosticsRequest2))
                return true;

            // If one is null, but not both, return false.
            if ((GetDiagnosticsRequest1 is null) || (GetDiagnosticsRequest2 is null))
                return false;

            return GetDiagnosticsRequest1.Equals(GetDiagnosticsRequest2);

        }

        #endregion

        #region Operator != (GetDiagnosticsRequest1, GetDiagnosticsRequest2)

        /// <summary>
        /// Compares two get diagnostics requests for inequality.
        /// </summary>
        /// <param name="GetDiagnosticsRequest1">A get diagnostics request.</param>
        /// <param name="GetDiagnosticsRequest2">Another get diagnostics request.</param>
        /// <returns>False if both match; True otherwise.</returns>
        public static Boolean operator != (GetDiagnosticsRequest GetDiagnosticsRequest1, GetDiagnosticsRequest GetDiagnosticsRequest2)

            => !(GetDiagnosticsRequest1 == GetDiagnosticsRequest2);

        #endregion

        #endregion

        #region IEquatable<GetDiagnosticsRequest> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Object">An object to compare with.</param>
        /// <returns>true|false</returns>
        public override Boolean Equals(Object Object)
        {

            if (Object is null)
                return false;

            if (!(Object is GetDiagnosticsRequest GetDiagnosticsRequest))
                return false;

            return Equals(GetDiagnosticsRequest);

        }

        #endregion

        #region Equals(GetDiagnosticsRequest)

        /// <summary>
        /// Compares two get diagnostics requests for equality.
        /// </summary>
        /// <param name="GetDiagnosticsRequest">A get diagnostics request to compare with.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public override Boolean Equals(GetDiagnosticsRequest GetDiagnosticsRequest)
        {

            if (GetDiagnosticsRequest is null)
                return false;

            return Location.Equals(GetDiagnosticsRequest.Location) &&

                   ((!StartTime.    HasValue && !GetDiagnosticsRequest.StartTime.    HasValue) ||
                     (StartTime.    HasValue &&  GetDiagnosticsRequest.StartTime.    HasValue && StartTime.    Value.Equals(GetDiagnosticsRequest.StartTime.    Value))) &&

                   ((!StopTime.     HasValue && !GetDiagnosticsRequest.StopTime.     HasValue) ||
                     (StopTime.     HasValue &&  GetDiagnosticsRequest.StopTime.     HasValue && StopTime.     Value.Equals(GetDiagnosticsRequest.StopTime.     Value))) &&

                   ((!Retries.      HasValue && !GetDiagnosticsRequest.Retries.      HasValue) ||
                     (Retries.      HasValue &&  GetDiagnosticsRequest.Retries.      HasValue && Retries.      Value.Equals(GetDiagnosticsRequest.Retries.      Value))) &&

                   ((!RetryInterval.HasValue && !GetDiagnosticsRequest.RetryInterval.HasValue) ||
                     (RetryInterval.HasValue &&  GetDiagnosticsRequest.RetryInterval.HasValue && RetryInterval.Value.Equals(GetDiagnosticsRequest.RetryInterval.Value)));

        }

        #endregion

        #endregion

        #region (override) GetHashCode()

        /// <summary>
        /// Return the HashCode of this object.
        /// </summary>
        /// <returns>The HashCode of this object.</returns>
        public override Int32 GetHashCode()
        {
            unchecked
            {

                return Location.GetHashCode() * 11 ^

                       (StartTime.HasValue
                            ? StartTime.    GetHashCode() * 7
                            : 0) ^

                       (StopTime.HasValue
                            ? StopTime.     GetHashCode() * 5
                            : 0) ^

                       (Retries.HasValue
                            ? Retries.      GetHashCode() * 3
                            : 0) ^

                       (RetryInterval.HasValue
                            ? RetryInterval.GetHashCode()
                            : 0);

            }
        }

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Return a text representation of this object.
        /// </summary>
        public override String ToString()

            => String.Concat(Location,

                             StartTime.HasValue
                                 ? ", from " + StartTime.Value.ToIso8601()
                                 : "",

                             StopTime.HasValue
                                 ? ", to "   + StopTime. Value.ToIso8601()
                                 : "",

                             Retries.HasValue
                                 ? ", " + Retries.Value + " retries"
                                 : "",

                             RetryInterval.HasValue
                                 ? ", retry interval " + RetryInterval.Value.TotalSeconds + " sec(s)"
                                 : "");

        #endregion

    }

}

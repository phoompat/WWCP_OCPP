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

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Hermod.JSON;

#endregion

namespace cloud.charging.adapters.OCPPv2_0.CS
{

    /// <summary>
    /// A heartbeat response.
    /// </summary>
    public class HeartbeatResponse : AResponse<CP.HeartbeatRequest,
                                                  HeartbeatResponse>
    {

        #region Properties

        /// <summary>
        /// The current time at the central system.
        /// </summary>
        public DateTime    CurrentTime    { get; }

        /// <summary>
        /// An optional custom data object to allow to store any kind of customer specific data.
        /// </summary>
        public CustomData  CustomData     { get; }

        #endregion

        #region Constructor(s)

        #region HeartbeatResponse(Request, CurrentTime, CustomData = null)

        /// <summary>
        /// Create a new heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="CurrentTime">The current time at the central system.</param>
        /// <param name="CustomData">An optional custom data object to allow to store any kind of customer specific data.</param>
        public HeartbeatResponse(CP.HeartbeatRequest  Request,
                                 DateTime             CurrentTime,
                                 CustomData           CustomData   = null)

            : base(Request,
                   Result.OK())

        {

            this.CurrentTime  = CurrentTime;
            this.CustomData   = CustomData;

        }

        #endregion

        #region HeartbeatResponse(Request, Result)

        /// <summary>
        /// Create a new heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="Result">The result.</param>
        public HeartbeatResponse(CP.HeartbeatRequest  Request,
                                 Result               Result)

            : base(Request,
                   Result)

        {

            this.CurrentTime = DateTime.UtcNow;

        }

        #endregion

        #endregion


        #region Documentation

        // {
        //   "$schema": "http://json-schema.org/draft-06/schema#",
        //   "$id": "urn:OCPP:Cp:2:2020:3:HeartbeatResponse",
        //   "comment": "OCPP 2.0.1 FINAL",
        //   "definitions": {
        //     "CustomDataType": {
        //       "description": "This class does not get 'AdditionalProperties = false' in the schema generation, so it can be extended with arbitrary JSON properties to allow adding custom data.",
        //       "javaType": "CustomData",
        //       "type": "object",
        //       "properties": {
        //         "vendorId": {
        //           "type": "string",
        //           "maxLength": 255
        //         }
        //       },
        //       "required": [
        //         "vendorId"
        //       ]
        //     }
        // },
        //   "type": "object",
        //   "additionalProperties": false,
        //   "properties": {
        //     "customData": {
        //       "$ref": "#/definitions/CustomDataType"
        //     },
        //     "currentTime": {
        //       "description": "Contains the current time of the CSMS.\r\n",
        //       "type": "string",
        //       "format": "date-time"
        //     }
        //   },
        //   "required": [
        //     "currentTime"
        //   ]
        // }

        #endregion

        #region (static) Parse   (Request, HeartbeatResponseJSON, OnException = null)

        /// <summary>
        /// Parse the given JSON representation of a heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="HeartbeatResponseJSON">The JSON to be parsed.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static HeartbeatResponse Parse(CP.HeartbeatRequest  Request,
                                              JObject              HeartbeatResponseJSON,
                                              OnExceptionDelegate  OnException = null)
        {

            if (TryParse(Request,
                         HeartbeatResponseJSON,
                         out HeartbeatResponse heartbeatResponse,
                         OnException))
            {
                return heartbeatResponse;
            }

            return null;

        }

        #endregion

        #region (static) Parse   (Request, HeartbeatResponseText, OnException = null)

        /// <summary>
        /// Parse the given text representation of a heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="HeartbeatResponseText">The text to be parsed.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static HeartbeatResponse Parse(CP.HeartbeatRequest  Request,
                                              String               HeartbeatResponseText,
                                              OnExceptionDelegate  OnException = null)
        {

            if (TryParse(Request,
                         HeartbeatResponseText,
                         out HeartbeatResponse heartbeatResponse,
                         OnException))
            {
                return heartbeatResponse;
            }

            return null;

        }

        #endregion

        #region (static) TryParse(Request, HeartbeatResponseJSON, out HeartbeatResponse, OnException = null)

        /// <summary>
        /// Try to parse the given JSON representation of a heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="HeartbeatResponseJSON">The JSON to be parsed.</param>
        /// <param name="HeartbeatResponse">The parsed heartbeat response.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(CP.HeartbeatRequest    Request,
                                       JObject                HeartbeatResponseJSON,
                                       out HeartbeatResponse  HeartbeatResponse,
                                       OnExceptionDelegate    OnException  = null)
        {

            try
            {

                HeartbeatResponse = null;

                #region CurrentTime

                if (!HeartbeatResponseJSON.ParseMandatory("currentTime",
                                                          "current time",
                                                          out DateTime  CurrentTime,
                                                          out String    ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region CustomData

                if (HeartbeatResponseJSON.ParseOptionalJSON("customData",
                                                            "custom data",
                                                            OCPPv2_0.CustomData.TryParse,
                                                            out CustomData  CustomData,
                                                            out             ErrorResponse,
                                                            OnException))
                {

                    if (ErrorResponse != null)
                        return false;

                }

                #endregion


                HeartbeatResponse = new HeartbeatResponse(Request,
                                                          CurrentTime,
                                                          CustomData);

                return true;

            }
            catch (Exception e)
            {

                OnException?.Invoke(DateTime.UtcNow, HeartbeatResponseJSON, e);

                HeartbeatResponse = null;
                return false;

            }

        }

        #endregion

        #region (static) TryParse(Request, HeartbeatResponseText, out HeartbeatResponse, OnException = null)

        /// <summary>
        /// Try to parse the given text representation of a heartbeat response.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        /// <param name="HeartbeatResponseText">The text to be parsed.</param>
        /// <param name="HeartbeatResponse">The parsed heartbeat response.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(CP.HeartbeatRequest    Request,
                                       String                 HeartbeatResponseText,
                                       out HeartbeatResponse  HeartbeatResponse,
                                       OnExceptionDelegate    OnException  = null)
        {

            try
            {

                HeartbeatResponseText = HeartbeatResponseText?.Trim();

                if (HeartbeatResponseText.IsNotNullOrEmpty() &&
                    TryParse(Request,
                             JObject.Parse(HeartbeatResponseText),
                             out HeartbeatResponse,
                             OnException))
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                OnException?.Invoke(DateTime.UtcNow, HeartbeatResponseText, e);
            }

            HeartbeatResponse = null;
            return false;

        }

        #endregion

        #region ToJSON(CustomHeartbeatResponseSerializer = null, CustomIdTagInfoResponseSerializer = null)

        /// <summary>
        /// Return a JSON representation of this object.
        /// </summary>
        /// <param name="CustomHeartbeatResponseSerializer">A delegate to serialize custom heartbeat responses.</param>
        /// <param name="CustomCustomDataResponseSerializer">A delegate to serialize CustomData objects.</param>
        public JObject ToJSON(CustomJObjectSerializerDelegate<HeartbeatResponse>  CustomHeartbeatResponseSerializer    = null,
                              CustomJObjectSerializerDelegate<CustomData>         CustomCustomDataResponseSerializer   = null)
        {

            var JSON = JSONObject.Create(

                           CustomData != null
                               ? new JProperty("customData",  CustomData.ToJSON(CustomCustomDataResponseSerializer))
                               : null,

                           new JProperty("currentTime",       CurrentTime.ToIso8601())

                       );

            return CustomHeartbeatResponseSerializer != null
                       ? CustomHeartbeatResponseSerializer(this, JSON)
                       : JSON;

        }

        #endregion


        #region Static methods

        /// <summary>
        /// The heartbeat failed.
        /// </summary>
        /// <param name="Request">The heartbeat request leading to this response.</param>
        public static HeartbeatResponse Failed(CP.HeartbeatRequest Request)

            => new HeartbeatResponse(Request,
                                     DateTime.UtcNow);

        #endregion


        #region Operator overloading

        #region Operator == (HeartbeatResponse1, HeartbeatResponse2)

        /// <summary>
        /// Compares two heartbeat responses for equality.
        /// </summary>
        /// <param name="HeartbeatResponse1">A heartbeat response.</param>
        /// <param name="HeartbeatResponse2">Another heartbeat response.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public static Boolean operator == (HeartbeatResponse HeartbeatResponse1, HeartbeatResponse HeartbeatResponse2)
        {

            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(HeartbeatResponse1, HeartbeatResponse2))
                return true;

            // If one is null, but not both, return false.
            if ((HeartbeatResponse1 is null) || (HeartbeatResponse2 is null))
                return false;

            return HeartbeatResponse1.Equals(HeartbeatResponse2);

        }

        #endregion

        #region Operator != (HeartbeatResponse1, HeartbeatResponse2)

        /// <summary>
        /// Compares two heartbeat responses for inequality.
        /// </summary>
        /// <param name="HeartbeatResponse1">A heartbeat response.</param>
        /// <param name="HeartbeatResponse2">Another heartbeat response.</param>
        /// <returns>False if both match; True otherwise.</returns>
        public static Boolean operator != (HeartbeatResponse HeartbeatResponse1, HeartbeatResponse HeartbeatResponse2)

            => !(HeartbeatResponse1 == HeartbeatResponse2);

        #endregion

        #endregion

        #region IEquatable<HeartbeatResponse> Members

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

            if (!(Object is HeartbeatResponse HeartbeatResponse))
                return false;

            return Equals(HeartbeatResponse);

        }

        #endregion

        #region Equals(HeartbeatResponse)

        /// <summary>
        /// Compares two heartbeat responses for equality.
        /// </summary>
        /// <param name="HeartbeatResponse">A heartbeat response to compare with.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public override Boolean Equals(HeartbeatResponse HeartbeatResponse)
        {

            if (HeartbeatResponse is null)
                return false;

            return CurrentTime.Equals(HeartbeatResponse.CurrentTime);

        }

        #endregion

        #endregion

        #region (override) GetHashCode()

        /// <summary>
        /// Return the HashCode of this object.
        /// </summary>
        /// <returns>The HashCode of this object.</returns>
        public override Int32 GetHashCode()

            => CurrentTime.GetHashCode();

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Return a text representation of this object.
        /// </summary>
        public override String ToString()

            => CurrentTime.ToIso8601();

        #endregion

    }

}

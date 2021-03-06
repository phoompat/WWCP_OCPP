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

#endregion

namespace cloud.charging.adapters.OCPPv2_0
{

    /// <summary>
    /// Extentions methods for the registration status.
    /// </summary>
    public static class RegistrationStatusExtentions
    {

        #region Parse(Text)

        /// <summary>
        /// Parse the given string as registration status.
        /// </summary>
        /// <param name="Text">A string representation of a registration status.</param>
        public static RegistrationStatus Parse(String Text)
        {

            switch (Text?.Trim())
            {

                case "Accepted":
                    return RegistrationStatus.Accepted;

                case "Pending":
                    return RegistrationStatus.Pending;

                case "Rejected":
                    return RegistrationStatus.Rejected;


                default:
                    return RegistrationStatus.Unknown;

            }

        }

        #endregion

        #region AsText(this RegistrationStatus)

        /// <summary>
        /// Return a string representation of the given registration status.
        /// </summary>
        /// <param name="RegistrationStatus">A registration status.</param>
        public static String AsText(this RegistrationStatus RegistrationStatus)
        {

            switch (RegistrationStatus)
            {

                case RegistrationStatus.Accepted:
                    return "Accepted";

                case RegistrationStatus.Pending:
                    return "Pending";

                case RegistrationStatus.Rejected:
                    return "Rejected";


                default:
                    return "unknown";

            }

        }

        #endregion

    }


    /// <summary>
    /// Result of a registration in response to a BootNotification request.
    /// </summary>
    public enum RegistrationStatus
    {

        /// <summary>
        /// Unknown registration status.
        /// </summary>
        Unknown,


        /// <summary>
        /// Charge point is accepted by the central system.
        /// </summary>
        Accepted,

        /// <summary>
        /// The central system is not yet ready to accept the
        /// charge point. The central system may send messages
        /// to retrieve information or prepare the charge point.
        /// </summary>
        Pending,

        /// <summary>
        /// Charge point is not accepted by the central system.
        /// This may happen when the charge point identification
        /// is not (yet) known by the central system.
        /// </summary>
        Rejected

    }

}

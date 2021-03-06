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

namespace cloud.charging.adapters.OCPPv1_6
{

    /// <summary>
    /// Extentions methods for the charging profile kinds.
    /// </summary>
    public static class ChargingProfileKindsExtentions
    {

        #region Parse(Text)

        public static ChargingProfileKinds Parse(String Text)
        {

            switch (Text?.Trim())
            {

                case "Absolute":
                    return ChargingProfileKinds.Absolute;

                case "Recurring":
                    return ChargingProfileKinds.Recurring;

                case "Relative":
                    return ChargingProfileKinds.Relative;


                default:
                    return ChargingProfileKinds.Unknown;

            }

        }

        #endregion

        #region AsText(this ChargingProfileKindType)

        public static String AsText(this ChargingProfileKinds ChargingProfileKindType)
        {

            switch (ChargingProfileKindType)
            {

                case ChargingProfileKinds.Absolute:
                    return "Absolute";

                case ChargingProfileKinds.Recurring:
                    return "Recurring";

                case ChargingProfileKinds.Relative:
                    return "Relative";


                default:
                    return "unknown";

            }

        }

        #endregion

    }


    /// <summary>
    /// Defines the charging-profile-kind-type-values.
    /// </summary>
    public enum ChargingProfileKinds
    {

        /// <summary>
        /// Unknown charging profile kind type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Schedule periods are relative to a fixed point in
        /// time defined in the schedule.
        /// </summary>
        Absolute,

        /// <summary>
        /// The schedule restarts periodically at the first schedule period.
        /// </summary>
        Recurring,

        /// <summary>
        /// Schedule periods are relative to a situationspecific start
        /// point (such as the start of a session) that is determined
        /// by the charge point.
        /// </summary>
        Relative

    }

}

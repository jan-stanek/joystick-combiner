﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

namespace JoystickCombiner.DeviceReaders
{
    class RudderReader : DeviceReader
    {
        public RudderReader(DirectInput directInput, string guid) : base(directInput, guid) {}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.DirectInput;

namespace JoystickCombiner.DeviceReaders
{
    class JoystickReader : DeviceReader
    {
        public JoystickReader(DirectInput directInput, string guid) : base(directInput, guid) {}
    }
}

/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2012-2013 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;

namespace Holotor.Hardware.Hardware.RAM;
internal class RAMGroup : IGroup
{

    private HardwareStack[] hardware;

    public RAMGroup(SMBIOS smbios, ISettings settings)
    {

        // No implementation for RAM on Unix systems
        if (OperatingSystem.IsUnix)
        {
            hardware = new HardwareStack[0];
            return;
        }

        hardware = new HardwareStack[] { new GenericRAM("Generic Memory", settings) };
    }

    public string GetReport()
    {
        return null;
    }

    public IHardware[] Hardware
    {
        get
        {
            return hardware;
        }
    }

    public void Close()
    {
        foreach (HardwareStack ram in hardware)
            ram.Close();
    }
}

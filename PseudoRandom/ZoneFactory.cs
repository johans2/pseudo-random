﻿using System;
using System.Collections.Generic;

namespace PseudoRandom
{
    public class ZoneFactory
    {
		private const int maxSeedValue = 20000;
		private ISystemCenterFactory systemCenterFactory;
		
        public ZoneFactory() 
        { 
			this.systemCenterFactory = new SystemCenterFactory();
		}

        public IZone CreateZone(int coordX, int coordY) 
        {
            Zone zone = new Zone();
            int[] seeds = RandomGenerator.GeneratePRandomSerie(coordX, coordY, maxSeedValue);
			double distance = Math.Sqrt(Math.Pow(coordX,2) + Math.Pow(coordY,2));
			
            zone.systemCenter = this.systemCenterFactory.CreateSystemCenter(seeds[0], distance);;
            
            return zone as IZone;
        }
    }
}

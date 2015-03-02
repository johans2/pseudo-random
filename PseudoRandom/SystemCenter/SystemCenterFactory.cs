using System;
using System.Collections.Generic;

namespace PseudoRandom
{
	public class SystemCenterFactory : ISystemCenterFactory
	{
		private List<IProbabilityItem> availableSystemCenters;
		private Dictionary<IProbabilityItem, Tuple<int,int>> systemCenterIntervals;
		
		public SystemCenterFactory ()
		{
			this.availableSystemCenters = RegisterSystemCenters();
			this.systemCenterIntervals = ProbabilityGenerator.GenerateIntervalls(availableSystemCenters, 5000);
		}
		
		public ISystemCenter CreateSystemCenter(int seed, double distance)
		{
			foreach (KeyValuePair<IProbabilityItem, Tuple<int,int>> s in systemCenterIntervals) 
			{
				if (s.Value.Item1 < seed && seed < s.Value.Item2) {
					ISystemCenter systemCenter = (ISystemCenter)Activator.CreateInstance(s.Key.GetType());
					if (distance > systemCenter.MinDistanceFromCenter) {
						return systemCenter;
					}
				}
			}
			
            return null;			
		}
		
		private List<IProbabilityItem> RegisterSystemCenters()
		{
			List<IProbabilityItem> systemCenters = new List<IProbabilityItem>();
			systemCenters.Add(new YellowStar());
			systemCenters.Add(new RedDwarfStar());
			systemCenters.Add(new WhiteDwarfStar());
			systemCenters.Add(new NeutronStar());
			systemCenters.Add(new BlueGiantStar());
			
			return systemCenters;
		}
	}
}


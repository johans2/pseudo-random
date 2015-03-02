using System;
using NUnit.Framework;
using PseudoRandom;
using System.Collections.Generic;

namespace Test
{
	internal class TestClass : IProbabilityItem
	{
		private double probability;
		
		public TestClass(double probability)
		{
			this.probability = probability;
		}
		
		public double RelativeProbability {
			get {
				return this.probability;
			}
			
		}
	}
	
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void ProbabilityTest ()
		{
			IProbabilityItem testItem1 = new TestClass(0.5);
			IProbabilityItem testItem2 = new TestClass(0.3);
			IProbabilityItem testItem3 = new TestClass(1);
			IProbabilityItem testItem4 = new TestClass(1);
			IProbabilityItem testItem5 = new TestClass(1.2);
			IProbabilityItem testItem6 = new TestClass(0.02);
			
			
			List<IProbabilityItem> items = new List<IProbabilityItem>();
			items.Add(testItem1);
			items.Add(testItem2);
			items.Add(testItem3);
			items.Add(testItem4);
			items.Add(testItem5);
			items.Add(testItem6);
			
			Dictionary<IProbabilityItem, Tuple<int, int>> intervals = ProbabilityGenerator.GenerateIntervalls(items, 10000);
			
			int a = 1;
		}
	}
}


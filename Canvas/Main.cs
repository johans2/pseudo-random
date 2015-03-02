using Gtk;
using Cairo;
using System;
using PseudoRandom;
using System.Collections.Generic;

namespace Canvas
{
	class SharpApp : Window {
 	
	public static int squareSize = 10;

    public SharpApp() : base("Simple drawing")
    {
        SetDefaultSize(1000, 1000);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };;
        
        DrawingArea darea = new DrawingArea();
        darea.ExposeEvent += OnExpose;

        Add(darea);

        ShowAll();
    }

    void OnExpose(object sender, ExposeEventArgs args)
    {
		// Register planets
		List<IProbabilityItem> stars = new List<IProbabilityItem>();
		stars.Add(new YellowStar());
		stars.Add(new RedDwarfStar());
		stars.Add(new WhiteDwarfStar());
		stars.Add(new NeutronStar());
		stars.Add(new BlueGiantStar());
		
		Dictionary<IProbabilityItem, Tuple<int,int>> starIntervals = ProbabilityGenerator.GenerateIntervalls(stars, 10000);
		
			
        DrawingArea area = (DrawingArea) sender;
        Cairo.Context cr =  Gdk.CairoHelper.Create(area.GdkWindow);
        
		ZoneFactory zf = new ZoneFactory();
                
        int width, height;
        width = Allocation.Width;
        height = Allocation.Height;

        cr.Translate(width/2, height/2);
        
		for (int x = -70; x < 70; x++) 
		{
			for (int y = -70; y < 70; y++) 
			{
				IZone zone = zf.CreateZone(x,y);
				cr.LineWidth = 2;
    			cr.SetSourceRGB(0, 0, 0);
        		
				cr.Rectangle(new PointD(x*(squareSize+2), (y*-1)*(squareSize+2)), squareSize, squareSize);
				cr.StrokePreserve();
				
				if (zone.systemCenter is RedDwarfStar) {
					cr.SetSourceRGB(0.8, 0.0, 0.0);
				}
				else if (zone.systemCenter is WhiteDwarfStar) {
					cr.SetSourceRGB(1, 1, 1);
				}
				else if (zone.systemCenter is YellowStar) {
					cr.SetSourceRGB(1, 0.9, 0);
				}
				else if (zone.systemCenter is BlueGiantStar) {
					cr.SetSourceRGB(0.2, 0.1, 1);
				}
				else if (zone.systemCenter is NeutronStar) {
					cr.SetSourceRGB(0.8, 0.8, 0.8);
				}
				else {
					cr.SetSourceRGB(0, 0, 0);		
				}
		        
		        cr.Fill();
			}
		}	
			
        ((IDisposable) cr.Target).Dispose();                                      
        ((IDisposable) cr).Dispose();
    }

    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
}

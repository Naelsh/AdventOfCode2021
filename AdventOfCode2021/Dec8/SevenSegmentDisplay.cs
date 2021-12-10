using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec8
{
    public class SevenSegmentDisplay
    {
        public List<Segment> Segments { get; set; } = new List<Segment>();

        public void SetupSegments(string[] input)
        {
            foreach (string row in input)
            {
                Segment newSegment = new Segment(row);
                Segments.Add(newSegment);
            }    
        }

        public int CountOnesFoursSevenEigths()
        {
            int count = 0; 
            foreach (Segment segment in Segments)
            {
                count += segment.CountOneFourSevenAndEigths();
            }
            return count;
        }

        public void PrepareSegments()
        {
            foreach (Segment segment in Segments)
            {
                segment.CreateDecoding();
                segment.FinalizeMap();
            }
        }

        public int GetOutputSum()
        {
            int sum = 0;
            foreach (Segment segment in Segments)
            {
                sum += segment.CalculateOuputValue();
            }
            return sum;
        }
    }
}

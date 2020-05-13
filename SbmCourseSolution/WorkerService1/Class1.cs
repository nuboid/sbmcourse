using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1
{

    public class Rootobject
    {
        public int nhits { get; set; }
        public Parameters parameters { get; set; }
        public Record[] records { get; set; }
        public Facet_Groups[] facet_groups { get; set; }
    }

    public class Parameters
    {
        public string dataset { get; set; }
        public string timezone { get; set; }
        public int rows { get; set; }
        public string format { get; set; }
        public string[] facet { get; set; }
    }

    public class Record
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public Fields fields { get; set; }
        public DateTime record_timestamp { get; set; }
    }

    public class Fields
    {
        public int occupiedplaces { get; set; }
        public string id { get; set; }
        public string facilityname { get; set; }
        public DateTime time { get; set; }
        public int freeplaces { get; set; }
        public int totalplaces { get; set; }
    }

    public class Facet_Groups
    {
        public Facet[] facets { get; set; }
        public string name { get; set; }
    }

    public class Facet
    {
        public int count { get; set; }
        public string path { get; set; }
        public string state { get; set; }
        public string name { get; set; }
    }

}

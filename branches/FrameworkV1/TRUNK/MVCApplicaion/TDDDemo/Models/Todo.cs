
namespace TDDDemo.Models {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Todo {
        public static List<Todo> ThingsToBeDone = new List<Todo> {
            new Todo{ Title = "Get Milk",Completed = true},
            new Todo{ Title = "Bring Home Bacon", Completed = false}
        };

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
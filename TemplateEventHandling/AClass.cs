using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEventHandling
{
   public class AClass
    {
        private int stateOfInterest;

        public event EventHandler StateOfInterestChanged;

        public int StateOfInterest 
        { 
            get
            {
                return this.stateOfInterest;
            }
            set
            { 
                if(this.stateOfInterest != value)
                {
                    this.stateOfInterest = value;
                    this.OnStateOfInterestChanged(EventArgs.Empty);
                }
            }
         }

        private void OnStateOfInterestChanged(EventArgs e)
        {
            EventHandler handler = this.StateOfInterestChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        public event EventHandler MyEvent;
    }


    public class BClass
    {
        AClass aclass;

        public BClass()
        {
            this.aclass = new AClass();
            this.aclass.StateOfInterestChanged += this.AClass_StateOfInterestChanged;
        }

        private void AClass_StateOfInterestChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
  
    }

    public class CClass
    {
        private ObservableCollection<AClass> listOfAClass;
        public CClass ()
	    {
            this.listOfAClass = new ObservableCollection<AClass>();
            this.listOfAClass.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ListOfAClass_CollectionChanged);
	    }

        private void ListOfAClass_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            e.OldItems.Cast<AClass>().ToList<AClass>()
            .ForEach(a => a.StateOfInterestChanged -= this.AClass_StateOfInterestChanged);

            e.NewItems.Cast<AClass>().ToList<AClass>()
                .ForEach(a => a.StateOfInterestChanged += this.AClass_StateOfInterestChanged);

        }

        private void AClass_StateOfInterestChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
       
    }
}
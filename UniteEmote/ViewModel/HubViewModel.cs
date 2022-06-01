using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Intel.Unite.Common.Display.Hub;

namespace UniteEmote.ViewModel
{
    [Serializable]
    class HubViewModel
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public HubAllocationInfo HubAllocationInfo { get; set; }
        public Guid ControlIdenfier { get; private set; }
        public bool IsAllocated { get; private set; }

        public HubViewModel()
        {
            IsAllocated = false;
        }

        public void AllocatedCallBack(HubAllocationResult hubAllocationResult)
        {
            if (hubAllocationResult.Success)
            {
                ControlIdenfier = hubAllocationResult.AllocatedView.Id;
                IsAllocated = true;
            }
            else
            {
                throw new Exception(hubAllocationResult.ResultType.ToString());
            }
        }

        public void DeallocatedCallBack(HubAllocationResult hubAllocationResult)
        {
            if (hubAllocationResult.Success)
            {
                IsAllocated = false;
            }
            else
            {
                throw new Exception(hubAllocationResult.ResultType.ToString());
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Intel.Unite.Common.Display.Hub;

namespace UnitePlugin.ViewModel
{
    [Serializable]
    public class HubViewModel
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public HubAllocationInfo HubAllocationInfo { get; set; }
        public Guid ControlIdentifier { get; set; }
        public bool IsAllocated { get; set; }

        public HubViewModel()
        {
            IsAllocated = false;
        }

        public void AllocatedCallBack(HubAllocationResult hubAllocationResult)
        {
            if (hubAllocationResult.Success)
            {
                ControlIdentifier = hubAllocationResult.AllocatedView.Id;
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

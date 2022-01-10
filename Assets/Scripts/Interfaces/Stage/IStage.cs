namespace Interfaces.Stage
{
    public interface IStage
    {
        public void Attach(IStageListener stageListener);
        
        public void Detach(IStageListener stageListener);

        public void Notify();
        
        public void AddRegion(IRegion region);

        public void FinishRegion(IRegion region);
    }
}
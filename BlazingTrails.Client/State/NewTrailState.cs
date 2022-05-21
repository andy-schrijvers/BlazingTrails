using BlazingTrails.Shared.Features.ManageTrails.Shared;

namespace BlazingTrails.Client.State
{
    public class NewTrailState
    {
        private TrailDto _unsavedTrail = new();
        public TrailDto GetTrail() => _unsavedTrail;
        public void SaveTrail(TrailDto trail) => _unsavedTrail = trail;
        public void ClearTrail() => _unsavedTrail = new();
    }
}

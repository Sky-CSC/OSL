using OSL_RGDP.Schema.Riot;

namespace OSL_RGDP.WebSocketResponse
{
    public class FearlessMatchDto
    {
        public int Index { get; set; }
        public MatchDto Match { get; set; }
        public FearlessMatchDto()
        {
            Index = -1;
            Match = new MatchDto();
        }
        public FearlessMatchDto(int index, MatchDto match)
        {
            Index = index;
            Match = match;

        }
    }

    public class FearlessMatchId
    {
        public Int64 MatchId { get; set; }
        public int Index { get; set; }
        public FearlessMatchId(Int64 matchId, int index)
        {
            MatchId = matchId;
            Index = index;
        }
    }
}

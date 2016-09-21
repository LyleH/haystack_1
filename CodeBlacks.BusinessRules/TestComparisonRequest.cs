namespace CodeBlacks.BusinessRules
{
    public sealed class TestComparisonRequest
    {
        public string TestDll { get; set; }

        public string TestToRun { get; set; }

        public string CodeCoverageFilter { get; set; }

        public string TestComparisonId { get; set; }
    }
}
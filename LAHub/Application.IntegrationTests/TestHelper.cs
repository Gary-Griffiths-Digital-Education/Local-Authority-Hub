namespace Application.IntegrationTests;

public static class TestHelper
{
    private static Testing? _testing;
    private static Object _thisLock = new Object();
    public static Testing CreateTesting()
    {
        lock (_thisLock)
        {
            if (_testing == null)
            {
                _testing = new Testing();
                _testing.RunBeforeAnyTests();
                Task.Run(() => Testing.ResetState()).Wait();
            }

            return _testing;
        }
            
    }
}

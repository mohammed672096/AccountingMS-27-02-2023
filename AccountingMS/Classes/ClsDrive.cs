namespace AccountingMS
{
    class ClsDrive
    {
        public static string Path { get; private set; } = MySetting.GetPrivateSetting.drive == null ? "C" : MySetting.GetPrivateSetting.drive;
        public static string LogPatth { get; private set; } = @$"{Path}:\B-Tech\Logs\log.txt";
    }
}

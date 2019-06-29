public static class StringTools 
{
    public static string BuildTimeString(float sec)
    {
        int minutes = (int)(sec / 60);
        int seconds = (int)(sec % 60);
        return string.Format("{0}:{1}", minutes, seconds);
    }

}

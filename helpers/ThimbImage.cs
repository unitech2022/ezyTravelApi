using System.Diagnostics;
using System.Threading; 

public class FFMPEG
{
    Process? ffmpeg;

    public void exec(string input, string output, string parametri)
    {
        ffmpeg = new Process();

        ffmpeg.StartInfo.Arguments = " -i " + input+ (parametri != null? " "+parametri:"")+" "+output; 
        ffmpeg.StartInfo.FileName = "/Users/gatekee/Downloads/ffmpeg.exe";
        ffmpeg.StartInfo.UseShellExecute = false;
        ffmpeg.StartInfo.RedirectStandardOutput = true;
        ffmpeg.StartInfo.RedirectStandardError = true;
        ffmpeg.StartInfo.CreateNoWindow = true;

        ffmpeg.Start();
        ffmpeg.WaitForExit();
        ffmpeg.Close();     
    }


    public void GetThumbnail(string video, string jpg, string velicina)
    {
        if (velicina == null) velicina = "640x480";
        exec(video, jpg, "-s "+velicina);
    }
}
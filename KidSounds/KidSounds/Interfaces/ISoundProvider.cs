using System;
using System.Threading.Tasks;
using System.Text;

namespace KidSounds.Interfaces
{
    public interface ISoundProvider
    {
        Task PlaySoundAsync(string filename);
    }
}

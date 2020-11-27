using SharpShell.Attributes;
using SharpShell.SharpThumbnailHandler;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayThumbnail
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.FileExtension, ".wotreplay")]
    public class ReplayThumbnailHandler : SharpThumbnailHandler
    {
        public ReplayThumbnailHandler()
        {
        }

        string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected override Bitmap GetThumbnailImage(uint width)
        {
            try
            {
                //  Create the bitmap dimensions
                var thumbnailSize = new Size((int)width, (int)width);

                //  Create the bitmap
                var bitmap = new Bitmap(thumbnailSize.Width, thumbnailSize.Height, PixelFormat.Format32bppArgb);

                //  Create a graphics object to render to the bitmap
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    //  Set the rendering up for anti-aliasing
                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                    //Draw the page background
                    var filename = this.SelectedItemStream.Name;

                    var minimaFilename = MapInfo.Maps.FirstOrDefault(i => i.IsMatching(filename));
                    if (minimaFilename == null)
                    {
                        throw new NullReferenceException("Map not recognized");
                    }
                    using (var minimap = Image.FromFile(Path.Combine(assemblyFolder, "Maps/" + minimaFilename.Minimap)))
                    {
                        graphics.DrawImage(minimap, 0, 0, thumbnailSize.Width, thumbnailSize.Height);
                    }
                }

                //  Return the bitmap
                return bitmap;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

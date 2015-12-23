using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerTATM
{
    public class MapHandler : IMapHandler // This is an example of The Middle-Man Class, Bad Smells
    {
        //Do Compression and Decompression here
        Compressor comp = new Compressor();
        Decompressor decomp = new Decompressor();

        public String CompressMap(String map)
        {
            String temp1 = "";
            String temp2 = "";
            String stage1 = comp.StageOneCompression(map);
            if (stage1 == map)
            {
                return stage1; // means that the map is not compressed, so do not decompress it
            }
            String stage2 = comp.StageTwoCompression(stage1);
            while (temp1 != stage2)
            {
                temp1 = temp2;
                if (stage2 == map)
                {
                    break;
                }
                else
                {
                    stage2 = comp.StageThreeCompression(stage2);
                }
                temp2 = stage2;
            }
            return stage2;
        }
        public String DecompressMap(String map)
        {
            String temp1 = "";
            String temp2 = "";
            String stage1 = decomp.StageOneDecompression(map);
            String stage2;
            if (stage1 == map)
            {
                return decomp.StageTwoDecompression(stage1); // means that the map is not compressed, so do not decompress it
            }
            while (temp1 != stage1)
            {
                temp1 = temp2;
                if (stage1 == map)
                {
                    break;
                }
                else
                {
                    stage1 = decomp.StageOneDecompression(stage1);
                }
                temp2 = stage1;
            }
            stage2 = decomp.StageTwoDecompression(stage1);// else decompress the map
            return stage2;
        }
    }
}

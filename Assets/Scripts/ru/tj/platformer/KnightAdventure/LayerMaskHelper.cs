using UnityEngine;

namespace ru.tj.platformer.KnightAdventure {
    public class LayerMaskHelper {
        public static int ToLayer(LayerMask layerMask) {
            int layerNumber = 0;
            int layer = layerMask.value;
            while (layer > 0) {
                layer = layer >> 1;
                layerNumber++;
            }

            return layerNumber - 1;
        }
    }
}
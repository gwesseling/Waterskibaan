using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.moves;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    static class MoveCollection {

        public static List<IMoves> Moves { get; } = new List<IMoves>() {
            new Jump(),
            new Flip(),
            new Roll(),
            new Koprol(),
        };

        public static List<IMoves> GetWillekeurigeMoves() {
            List<IMoves> moves = new List<IMoves>();
            Random r = new Random();

            foreach (IMoves m in MoveCollection.Moves) {
                int mc = r.Next(2);

                if (mc == 0) {
                    moves.Add(m);
                }
            }

            return moves;
        }

    }
}

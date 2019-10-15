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

            foreach (IMoves m in MoveCollection.Moves) {
                int r = new Random().Next(2);

                if (r == 1) {
                    moves.Add(m);
                }
            }

            return moves;
        }

    }
}

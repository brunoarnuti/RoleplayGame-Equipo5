using System;
using System.Collections.Generic;

namespace RolGame
{
    public class ComposedItem : Item
    {
        private List<Item> pieces;
        private int baseAttack;
        private int baseDefense;
 

        public ComposedItem(string name, int attack, int defense) : base(name, attack, defense)
        {
            this.pieces = new List<Item>();
            this.baseAttack = attack;
            this.baseDefense = defense;
        }

        public override int GetItemAttack()
        {
            int result = baseAttack;
            foreach (Item piece in pieces)
            {
                result = result + piece.GetItemAttack();
            }
            return result;
        }

        public override int GetItemDefense()
        {
            int result = baseDefense;
            foreach (Item piece in pieces)
            {
                result = result + piece.GetItemDefense();
            }
            return result;
        }

        public void AddPiece(Item piece)
        {
            this.pieces.Add(piece);
            this.UpdateComposedItemStats();
        }
        public void RemovePiece(Item piece)
        {
            if(this.pieces.Contains(piece))
            {
                this.pieces.Remove(piece);
                this.UpdateComposedItemStats();
            }
        }

        private void UpdateComposedItemStats()
        {
            this.itemAttack = this.GetItemAttack();
            this.itemDefense = this.GetItemDefense();
        }
    }
}

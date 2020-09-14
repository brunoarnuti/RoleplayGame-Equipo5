using System;
using System.Collections.Generic;

namespace RolGame
{
    public class ComposedItem : Item
    {
        private List<Item> pieces;
        private int itemAttack;
        private int itemDefense;

        public ComposedItem(string name, int attack, int defense) : base(name, attack = 0, defense = 0)
        {
            this.pieces = new List<Item>();
        }

        public override int GetItemAttack()
        {
            int result = 0;
            foreach (Item piece in pieces)
            {
                result = result + piece.GetItemAttack();
            }
            return result;
        }

        public override int GetItemDefense()
        {
            int result = 0;
            foreach (Item piece in pieces)
            {
                result = result + piece.GetItemDefense();
            }
            return result;
        }

        public void AddPiece(Item piece)
        {
            this.pieces.Add(piece);
            this.UpdateComposedItemStats(piece);
        }
        public void RemovePiece(Item piece)
        {
            if(this.pieces.Contains(piece))
            {
                this.pieces.Remove(piece);
                this.UpdateComposedItemStats(piece);
            }
        }

        private void UpdateComposedItemStats(Item piece)
        {
            this.itemAttack = this.GetItemAttack() + piece.GetItemAttack();
            this.itemDefense = this.GetItemDefense();
        }
    }
}

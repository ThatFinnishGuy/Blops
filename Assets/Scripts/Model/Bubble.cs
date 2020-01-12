using UnityEngine;
using System.Collections;

namespace com.javierquevedo{
	public enum BubbleColor {Purple, Blue, Red, White, Yellow, Orange};
    
	public class Bubble {
		
		private BubbleColor _color;
		
		public Bubble(BubbleColor color, uint value){
			this._color = color;
		}
		
		public BubbleColor color{
			get{
				return this._color;
			}
			set {
				this._color = value;
			}
		}
		
	}
}

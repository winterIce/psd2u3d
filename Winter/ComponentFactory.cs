namespace Winter
{
	using System;
    using UnityEngine;
	
    public class ComponentFactory
	{
	    public static ISkinable createComponentByType(String type)
		{
			ISkinable child = null;
			switch(type)
			{
			    case "Label":
				    child = new Label();
				    break;
				case "ScaleImage":
					child = new Image();
					break;
				case "Image":
					child = new Image();
					break;
				case "Button":
					child = new Button();
					break;
				case "DragBar":
					child = new DragBar();
					break;
			    case "DragDropRoot":
				    child = new MyDragDropRoot();
				    break;
				case "Container":
					child = new Container();
					break;
				case "RadioButtonGroup":
					child = new RadioButtonGroup();
					break;
				case "RadioButton":
					child = new RadioButton();
					break;
				case "Stepper":
					child = new Stepper();
					break;
				case "ScrollBar":
					child = new ScrollBar();
					break;
				/*
				case "LabelButton":
					child = new LabelButton();
					break;
				case "List":
					child = new List();
					break;
				case "Slider":
					child = new Slider();
					break;
				case "ComboBox":
					child = new ComboBox();
					break;
					*/
			}
			return child;
		}
    }
}

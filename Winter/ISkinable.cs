namespace Winter
{
    using System;
    using LitJson;

    public interface ISkinable
    {
	    JsonData skin{ get; set;}
	    void AfterSkin();
	}    
}

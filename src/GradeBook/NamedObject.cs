using System;

namespace GradeBook
{
    public class NamedObject
    {
        #region constructor
        public NamedObject(string name)
        {
            Name = name;
        }
        #endregion
        
        #region fields
        string name;
        #endregion

        #region properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException($"Please assign a valid {nameof(name)}");
                }
            }
        }
        #endregion
    }
}
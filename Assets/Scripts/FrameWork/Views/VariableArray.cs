using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[System.Serializable]
public enum VariableType
{
    Object,
    GameObject,
    Component
}

[System.Serializable]
public class Variable
{
    [SerializeField]
    protected string name = string.Empty;
    [SerializeField]
    protected VariableType variableType;
    [SerializeField]
    protected Object objvalue;
    private List<Variable> variables;

    public Variable(string name, VariableType variableType, Object objvalue)
    {
        this.name = name;
        this.variableType = variableType;
        this.objvalue = objvalue;
    }

    public virtual string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual VariableType VariableType
    {
        get { return variableType; }
    }

    public virtual System.Type ValueType
    {
        get
        {
            switch (variableType)
            {
                case VariableType.Object:
                    return this.objvalue == null ? typeof(UnityEngine.Object) : this.objvalue.GetType();
                case VariableType.GameObject:
                    return this.objvalue == null ? typeof(GameObject) : this.objvalue.GetType();
                case VariableType.Component:
                    return this.objvalue == null ? typeof(Component) : this.objvalue.GetType();
                default:
                    throw new System.NotSupportedException();
            }
        }
    }

    public virtual void SetValue<T>(T value)
    {
        SetValue(value);
    }

    public virtual T GetValue<T>()
    {
        return (T)GetValue();
    }


    public virtual void SetValue(object value)
    {
        switch (variableType)
        {
            case VariableType.Object:
                objvalue = (UnityEngine.Object)value;
                break;
            case VariableType.GameObject:
                objvalue = (GameObject)value;
                break;
            case VariableType.Component:
                objvalue = (Component)value;
                break;
            default:
                throw new System.NotSupportedException();
        }
    }

    public virtual object GetValue()
    {
        switch (this.variableType)
        {
            case VariableType.Object:
                return this.objvalue;
            case VariableType.GameObject:
                return this.objvalue;
            case VariableType.Component:
                return this.objvalue;
            default:
                throw new System.NotSupportedException();
        }
    }

}

[System.Serializable]
public class VariableArray
{
    [SerializeField]
    private List<Variable> variables;

    public ReadOnlyCollection<Variable> Variables
    {
        get { return variables.AsReadOnly(); }
    }

    public Variable this[int index]
    {
        get { return variables[index]; }
    }

    public object Get(string name)
    {
        if (this.variables == null || this.variables.Count <= 0)
            return null;
        var variable = this.variables.Find(v => v.Name.Equals(name));
        if (variable == null)
            return null;
        return variable.GetValue();
    }

    public void AddVariable(string name, VariableType variableType, Object obj)
    {
        if (variables == null)
        {
            variables = new List<Variable>();
        }
        variables.Add(new Variable(name, variableType, obj));
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BedrockBoot.Entity;

public class INIConfigEntity
{
    private readonly Dictionary<string, string> _config = new Dictionary<string, string>();
    private readonly string _filePath;
    
    public INIConfigEntity(string filePath)
    {
        _filePath = filePath;
        Load();
    }
    
    public void Load()
    {
        _config.Clear();
        
        if (!File.Exists(_filePath))
            return;
            
        var lines = File.ReadAllLines(_filePath);
        
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            
            // 跳过空行和注释
            if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                continue;
                
            var colonIndex = trimmed.IndexOf(':');
            if (colonIndex <= 0) continue;
            
            var key = trimmed.Substring(0, colonIndex).Trim();
            var value = trimmed.Substring(colonIndex + 1).Trim();
            
            _config[key] = value;
        }
    }
    
    public void Save()
    {
        var sb = new StringBuilder();
        
        foreach (var kvp in _config)
        {
            sb.AppendLine($"{kvp.Key}:{kvp.Value}");
        }
        
        File.WriteAllText(_filePath, sb.ToString());
    }
    
    public string Get(string key, string defaultValue = "")
    {
        return _config.TryGetValue(key, out var value) ? value : defaultValue;
    }
    
    public void Set(string key, string value)
    {
        _config[key] = value;
    }
    
    public void Set(string key, int value)
    {
        _config[key] = value.ToString();
    }
    
    public void Set(string key, float value)
    {
        _config[key] = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }
    
    public void Set(string key, bool value)
    {
        _config[key] = value ? "1" : "0";
    }
    
    public void SetArray(string key, string[] values)
    {
        if (values == null || values.Length == 0)
        {
            _config[key] = "[]";
        }
        else
        {
            var formatted = "[\"" + string.Join("\",\"", values) + "\"]";
            _config[key] = formatted;
        }
    }
    
    public int GetInt(string key, int defaultValue = 0)
    {
        if (_config.TryGetValue(key, out var value) && int.TryParse(value, out int result))
            return result;
        return defaultValue;
    }
    
    public float GetFloat(string key, float defaultValue = 0f)
    {
        if (_config.TryGetValue(key, out var value) && 
            float.TryParse(value, System.Globalization.NumberStyles.Float, 
                System.Globalization.CultureInfo.InvariantCulture, out float result))
            return result;
        return defaultValue;
    }
    
    public bool GetBool(string key, bool defaultValue = false)
    {
        if (_config.TryGetValue(key, out var value))
        {
            if (value == "1") return true;
            if (value == "0") return false;
            if (bool.TryParse(value, out bool result)) return result;
        }
        return defaultValue;
    }
    
    public string[] GetArray(string key)
    {
        if (_config.TryGetValue(key, out var value))
        {
            var trimmed = value.Trim();
            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                var content = trimmed.Substring(1, trimmed.Length - 2);
                return content.Split(',')
                    .Select(s => s.Trim().Trim('"'))
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray();
            }
        }
        return Array.Empty<string>();
    }
}
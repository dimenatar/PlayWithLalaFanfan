using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    [SerializeField] private int _rows;
    [SerializeField] protected int _columns;
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private Vector2 _spacing;
    [SerializeField] private FitType _fitType;
    [SerializeField] private bool _fitX;
    [SerializeField] private bool _fitY;
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }

    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrt = Mathf.Sqrt(transform.childCount);
        _rows = Mathf.CeilToInt(sqrt);
        _columns = Mathf.CeilToInt(sqrt);

        if (_fitType == FitType.Width)
        {
            _rows = Mathf.CeilToInt(transform.childCount / _columns);
        }
        if (_fitType == FitType.Height)
        {
            _columns = Mathf.CeilToInt(transform.childCount / _rows);
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        Debug.Log(_columns);
        float cellWidth = parentWidth / _columns - _spacing.x / _columns * 2 - padding.left/_columns - padding.left / _columns;
        float cellHeight = parentHeight / _rows - _spacing.y / _rows * 2 - padding.top / _rows - padding.bottom / _rows;

        _cellSize.x = cellWidth;
        _cellSize.y = cellHeight;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / _columns;
            columnCount = i % _columns;

            var item = rectChildren[i];

            var xPos = _cellSize.x * columnCount + _spacing.x * columnCount + padding.left;
            var yPos = _cellSize.y * rowCount + _spacing.y * rowCount + padding.top;

            SetChildAlongAxis(item, 0, xPos, _cellSize.x);
            SetChildAlongAxis(item, 1, yPos, _cellSize.y);
        }
    }

    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {

    }
}

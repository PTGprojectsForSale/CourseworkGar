using System.Collections;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    public Renderer enemyRenderer;          // Рендерер врага
    public Color hitColor = Color.red;      // Цвет покраснения
    public float effectDuration = 0.5f;    // Длительность эффекта

    private Material[] enemyMaterials;     // Массив материалов
    private Color[] originalColors;        // Исходные цвета всех материалов

    void Start()
    {
        enemyMaterials = enemyRenderer.materials;
        originalColors = new Color[enemyMaterials.Length];

        for (int i = 0; i < enemyMaterials.Length; i++)
        {
            originalColors[i] = enemyMaterials[i].color;
        }
    }

    public void ApplyHitEffect()
    {
        StartCoroutine(HitEffectCoroutine());
    }

    private IEnumerator HitEffectCoroutine()
    {
        // Меняем цвет каждого материала на цвет удара
        for (int i = 0; i < enemyMaterials.Length; i++)
        {
            enemyMaterials[i].color = hitColor;
        }

        // Ждём указанное время
        yield return new WaitForSeconds(effectDuration);

        // Возвращаем исходные цвета
        for (int i = 0; i < enemyMaterials.Length; i++)
        {
            enemyMaterials[i].color = originalColors[i];
        }
    }
}

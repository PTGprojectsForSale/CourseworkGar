using System.Collections;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    public Renderer enemyRenderer;          // �������� �����
    public Color hitColor = Color.red;      // ���� �����������
    public float effectDuration = 0.5f;    // ������������ �������

    private Material[] enemyMaterials;     // ������ ����������
    private Color[] originalColors;        // �������� ����� ���� ����������

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
        // ������ ���� ������� ��������� �� ���� �����
        for (int i = 0; i < enemyMaterials.Length; i++)
        {
            enemyMaterials[i].color = hitColor;
        }

        // ��� ��������� �����
        yield return new WaitForSeconds(effectDuration);

        // ���������� �������� �����
        for (int i = 0; i < enemyMaterials.Length; i++)
        {
            enemyMaterials[i].color = originalColors[i];
        }
    }
}

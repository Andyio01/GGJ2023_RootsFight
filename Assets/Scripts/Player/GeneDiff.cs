using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GeneDiff : MonoBehaviour {
    public GameObject[] AA;
    public GameObject[] Aa;
    public GameObject[] aa;
    public GameObject[] BB;
    public GameObject[] Bb;
    public GameObject[] bb;
    public GameObject[] CC;
    public GameObject[] Cc;
    public GameObject[] cc;

    public void GeneSelect(string gene) {
        if (gene.Contains("AA")) {
            foreach (var angle in AA) angle.SetActive(true);
            foreach (var angle in Aa) angle.SetActive(false);
            foreach (var angle in aa) angle.SetActive(false);
        } else if (gene.Contains("Aa") || gene.Contains("aA")) {
            foreach (var angle in AA) angle.SetActive(false);
            foreach (var angle in Aa) angle.SetActive(true);
            foreach (var angle in aa) angle.SetActive(false);
        } else {
            foreach (var angle in AA) angle.SetActive(false);
            foreach (var angle in Aa) angle.SetActive(false);
            foreach (var angle in aa) angle.SetActive(true);
        }

        if (gene.Contains("BB")) {
            foreach (var body in BB) body.SetActive(true);
            foreach (var body in Bb) body.SetActive(false);
            foreach (var body in bb) body.SetActive(false);
        } else if (gene.Contains("Bb") || gene.Contains("bB")) {
            foreach (var body in BB) body.SetActive(false);
            foreach (var body in Bb) body.SetActive(true);
            foreach (var body in bb) body.SetActive(false);
        } else {
            foreach (var body in BB) body.SetActive(false);
            foreach (var body in Bb) body.SetActive(false);
            foreach (var body in bb) body.SetActive(true);
        }

        if (gene.Contains("CC")) {
            foreach (var tail in CC) tail.SetActive(true);
            foreach (var tail in Cc) tail.SetActive(false);
            foreach (var tail in cc) tail.SetActive(false);
        } else if (gene.Contains("Cc") || gene.Contains("cC")) {
            foreach (var tail in CC) tail.SetActive(false);
            foreach (var tail in Cc) tail.SetActive(true);
            foreach (var tail in cc) tail.SetActive(false);
        } else {
            foreach (var tail in CC) tail.SetActive(false);
            foreach (var tail in Cc) tail.SetActive(false);
            foreach (var tail in cc) tail.SetActive(true);
        }
    }
}
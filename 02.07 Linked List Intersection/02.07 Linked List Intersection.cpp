// 02.07 Linked List Intersection.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

class Node {
public:	
	Node *next;
	int value;
};

Node *Intersection(Node*, Node*);
int GetLengthofLinkedList(Node*);
void Swap(int*, int*);
void Swap(Node*, Node*);

int NullHeadsBoth();
int NullHeadsOne();
int SameNodeBoth();
int DisjointNodes();

int main(){
	int count = 0;
	if (NullHeadsBoth()) {
		count += NullHeadsBoth();
		std::cout << "NullHeadsBoth failed" << std::endl;
	}
	if (NullHeadsOne()) {
		count += NullHeadsOne();
		std::cout << "NullHeadsOne failed" << std::endl;
	}
	if (SameNodeBoth()) {
		count += SameNodeBoth();
		std::cout << "SameNodeBoth failed" << std::endl;
	}
	if (DisjointNodes()) {
		count += DisjointNodes();
		std::cout << "DisjointNodes failed" << std::endl;
	}
	return count;
}

Node *Intersection(Node *head1, Node *head2) {
	int length1 = GetLengthofLinkedList(head1);
	int length2 = GetLengthofLinkedList(head2); // check for zero length here

	if (length1 == 0 || length2 == 0)
		return NULL;

	if (length2 < length1) {
		Swap(&length1, &length2); // can I directly change stack values? // only if I pass reference
		Swap(head1, head2);
	}

	while (length1 < length2--)
		head2 = head2->next; // how does one move a pointer?

	if (head1 == head2)
		return head1;

	while (head1->next != head2->next) { // same length, no NRE b/c null == null at end
		head1 = head1->next;
		head2 = head2->next;
	}
	return head1->next;
};

void Swap(int* int1, int* int2) {
	int* temp = int1;
	int1 = int2;
	int2 = temp;
}

void Swap(Node* node1, Node* node2) {
	Node* temp = node1;
	node1 = node2;
	node2 = temp;
}

int GetLengthofLinkedList(Node* head) {
	if (head == NULL)
		return 0;
	Node* temp = head;
	int count = 1;
	while (temp->next != NULL) {
		temp = temp->next;
		count++;
	}
	return count;
}

int NullHeadsBoth() {
	Node* head = NULL;
	if (Intersection(head, head) != NULL)
		return 1;
	return 0;
}

int NullHeadsOne() {
	Node* nullHead = NULL;
	Node* node = new Node();
	node->value = 3;

	int count = 0;
	if (Intersection(nullHead, node) != NULL)
		count++;
	if (Intersection(node, nullHead) != NULL)
		count++;
	return count;
}

int SameNodeBoth(){
	Node* node = new Node();
	node->value = 4;

	if (Intersection(node, node) != node)
		return 1;
	return 0;
}

int DisjointNodes() {
	Node* node1 = new Node();
	node1->value = 1;
	Node* node2 = new Node();
	node2->value = 2;

	int count = 0;
	if (Intersection(node1, node2) != NULL)
		count++;
	if (Intersection(node2, node1) != NULL)
		count++;
	return count;
}

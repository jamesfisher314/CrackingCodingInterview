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
int IntersectAtHead();
int LargeLL();
Node* GenerateLL(Node * &head1, int n);
Node* GenerateNode();
int FindReference(Node* head, Node* search);

int main(){
	int count = 0;
	if (NullHeadsBoth()) {
		count += NullHeadsBoth();
		std::cout << "NullHeadsBoth failed" << std::endl;
	}
	if (NullHeadsOne()) {
		count += NullHeadsOne();
		std::cout << "NullHeadsOne failed" << std::endl;
	}/**/
	if (SameNodeBoth()) {
		count += SameNodeBoth();
		std::cout << "SameNodeBoth failed" << std::endl;
	}/**/
	if (DisjointNodes()) {
		count += DisjointNodes();
		std::cout << "DisjointNodes failed" << std::endl;
	}/**/
	if (IntersectAtHead()) {
		count += IntersectAtHead();
		std::cout << "IntersectAtHead failed" << std::endl;
	}/**/
	if (LargeLL()) {
		count += LargeLL();
		std::cout << "LargeLL failed" << std::endl;
	}/**/
	return count;
}

Node *Intersection(Node *head1, Node *head2) {

	int length1 = GetLengthofLinkedList(head1);
	int length2 = GetLengthofLinkedList(head2);

	if (length1 == 0 || length2 == 0)
		return NULL;

	if (head1 == head2)
		return head1;

	// Store to repair heads after swap
	Node temp1 = *head1;
	Node temp2 = *head2;
	std::cout << length1 << ' ' << length2 << std::endl <<
		"head1 " << head1->next << std::endl <<
		"head2 " << head2->next << std::endl;
	bool swapped = false;
	if (length2 < length1) {
		Swap(&length1, &length2);
		Swap(&temp1, &temp2);
		swapped = true;
	}

	while (temp2.next != head1 && temp2.next != head2 && length1 < length2--)
		temp2 = *(temp2.next); // Accidentally decreases length2 during last check
	
	if (temp1.next == (swapped ? head1 : head2))
		return swapped ? head1 : head2;
	if (temp2.next == (swapped ? head2 : head1))
		return swapped ? head2 : head1;

	while (temp1.next != temp2.next) {
		temp1 = *(temp1.next);
		temp2 = *(temp2.next);
	}

	return head1->next;
};

void Swap(int* int1, int* int2) {
	int temp = *int1;
	*int1 = *int2;
	*int2 = temp;
}

void Swap(Node* node1, Node* node2) {
	Node temp = *node1;
	*node1 = *node2;
	*node2 = temp;
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
	std::cout << "NullHeadsBoth begin: " << std::endl;
	Node* head = NULL;
	if (Intersection(head, head) != NULL)
		return 1;
	return 0;
}

int NullHeadsOne() {
	std::cout << "NullHeadsOne begin: " << std::endl;
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
	std::cout << "SameNodeBoth begin: " << std::endl;
	Node* node = new Node();
	node->value = 4;

	Node* result = Intersection(node, node);
	if (result != node) {
		if (result == NULL)
			std::cout << "result was null " << std::endl;
		else
			std::cout << (long)result << ' ' << (long)result->next << ' ' << result->value << std::endl;
		std::cout << (long)node << ' ' << (long)node->next << ' ' << node->value << std::endl;
		return 1;
	}
	return 0;
}

int DisjointNodes() {
	std::cout << "DisjointNodes begin: " << std::endl;
	Node* node1 = new Node();
	node1->value = 1;
	Node* node2 = new Node();
	node2->value = 2;

	int count = 0;
	Node* result = Intersection(node1, node2);
	if (result != NULL)
		count++;
	result = Intersection(node2, node1);
	if (result != NULL)
		count++;
	return count;
}

int IntersectAtHead(){
	std::cout << "IntersectAtHead begin: " << std::endl;
	Node* head1 = new Node();
	head1->value = 3;
	Node* head2 = new Node();
	head2->value = 4;

	head1->next = new Node();
	head1->next->value = 1;
	head1->next->next = new Node();
	head1->next->next->value = 4;

	Node* join = new Node();
	join->value = 1;
	head1->next->next->next = join;
	head2->next = join;

	join->next = new Node();
	join->next->value = 5;
	join->next->next = new Node();
	join->next->next->value = 9;
	std::cout << "join address is: " << join << std::endl;
	int count = 0;
	Node* result = Intersection(head1, head2);
	std::cout << "IntersectAtHead result is: " << result << std::endl;
	if (result != join)
		count++;
	result = Intersection(head2, head1);
	std::cout << "IntersectAtHead result is: " << result << std::endl;
	if (result != join)
		count++;
	return count;
}

int LargeLL() {
	std::cout << "LargeLL begin: " << std::endl;
	Node* head1 = GenerateNode();
	Node* head2 = GenerateNode();
	Node* intersect = GenerateNode();

	Node* traverse = GenerateLL(head1, 23);
	traverse->next = intersect;
	traverse = GenerateLL(head2, 17);
	traverse->next = intersect;
	GenerateLL(intersect, 31);

	std::cout << "Lengths: " << GetLengthofLinkedList(head1) << " " << GetLengthofLinkedList(head2) << std::endl;

	std::cout << "intersect address is: " << intersect << std::endl;
	int count = 0;
	Node* result = Intersection(head1, head2);
	std::cout << "LargeLL result is: " << result << std::endl;
	if (result != intersect)
		count++;
	std::cout << "Found result at head1's " << FindReference(head1, result) << " and head2's " << FindReference(head2, result) << std::endl;
	result = Intersection(head2, head1);
	std::cout << "LargeLL result is: " << result << std::endl;
	if (result != intersect)
		count++;
	std::cout << "Found result at head1's " << FindReference(head1, result) << " and head2's " << FindReference(head2, result) << std::endl;
	return count;
}

Node* GenerateLL(Node * &head1, int n){
	Node** traverse = &head1;
	for (int i = 0; i < n; i++) {
		(*traverse)->next = GenerateNode();
		traverse = &((*traverse)->next);
	}
	return *traverse;
}

Node* GenerateNode() {
	Node* node = new Node();
	node->value = 0;
	return node;
}

int FindReference(Node* head, Node* search) {
	int count = 0;
	if (search == head)
		return count;
	Node indexer = *(head);
	count++;
	while (indexer.next != search && indexer.next != NULL) {
		indexer = *(indexer.next);
		count++;
	}
	if (indexer.next == search)
		return count;
	return -1;
}

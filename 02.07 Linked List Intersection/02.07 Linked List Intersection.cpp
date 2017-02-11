// 02.07 Linked List Intersection.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

class Node {
public:	
	Node *next;
	int value;
};

Node *Intersection(Node*, Node*);
int *GetLengthofLinkedList(Node*);
void Swap(int*, int*);
void Swap(Node*, Node*);

int main()
{
    return 0;
}

Node *Intersection(Node *head1, Node *head2) {
	int *length1 = GetLengthofLinkedList(head1);
	int *length2 = GetLengthofLinkedList(head2); // check for zero length here

	if (length2 < length1) {
		Swap(length1, length2); // can I directly change stack values? // only if I pass reference
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

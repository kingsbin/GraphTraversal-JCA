using System;
using System.Data;
namespace GraphTraversal
{
    // to handle circular queues the routines to increment points always store the modula of the index and maxsize 
    //this means if maxlength is 4 then attempting to increment to 4 will cause it to wrap back to 0
    class MyQueue {
        bool isEmpty;
        bool isFull;
        int maxSize;
        string[] queue;
        int front;
        int rear;
        bool error;
        string msg;

        public bool IsEmpty {get {return isEmpty;}}
        public bool IsFull {get {return isFull;}}  
        public bool Error {get {return error;}}
        public string Msg {get {return msg;}}

        public MyQueue(int m){
            maxSize=m;
            queue=new string[maxSize];
            front=0;
            rear=-1;
            isEmpty=true;
            isFull=false;
            error = false;
            msg="";
        }  

        //checks if rear is 1 less than front OR front =0 and rear is size 
        //this indicates queue is either full or empty (depending on last operation)
        private bool CapacityCheck(){
            return (rear-front+1) % maxSize == 0;
        }

        private int adjIdx(int idx){
            return idx % maxSize;
        }

        public void EnQueue(string item) {
            if (!isFull){
                rear =adjIdx(rear+1);       //wrap rear back to 0 if necc
                queue[rear] = item;
                error=false;;
                msg="Enqueued";
                isFull=CapacityCheck();
                isEmpty=false;
            } else {
                error=true;
                msg="Queue Overflow";
            }

        }

        public string DeQueue(){
            string rval="";
            if (!isEmpty){
                rval= queue[front];
                front=adjIdx(front+1);            //wrap front back to 0 if necc
                error=false;;
                msg="Dequeued";
                isEmpty=CapacityCheck();
                isFull=false;
            } else {
                error=true;
                msg="Underflow";
            }
            return rval;
        }

        public string Peek(){
            string rval="";
            if (!isEmpty){
                rval= queue[front];
            } else {
                error=true;
                msg="Empty Queue";
            }
            return rval;
        }

        public void ResetError(){
            error=false;;
            msg="";
        }

        public void PrintQueue(){
            Console.WriteLine("--Queue-------");
            if (isEmpty){
                 Console.WriteLine("  Empty");
            } else {
                int modrear;
                if (rear < front){
                    modrear=rear + maxSize;
                } else {
                    modrear=rear;
                }

                for (int i=front; i<=modrear; i++){
                    int idx=adjIdx(i);
                    Console.WriteLine($"{queue[idx]}");
                }

            }
            Console.WriteLine("-------------");

        }
        

    }
    class MyStack{
        bool isEmpty;
        bool isFull;
        int maxSize;
        string[] stack;
        int head;
        bool err;
        string msg;
        
        public bool IsEmpty{get {return isEmpty;} }
        public bool IsFull{get {return isFull;} }
        public bool Error {get {return err;}}
        public string Msg {get {return msg;}}

        public MyStack(int ms) {
            maxSize=ms;
            stack = new string[maxSize];
            isEmpty=true;
            isFull=false;
            head=-1;
        }

        public string Pop(){
            string rval="";
            if (isEmpty) {
                msg= "Error - Stack Underflow";
                err=true;
            } else {
                rval=stack[head];
                stack[head]="";
                head --;
                if (head == -1) {
                    isEmpty=true;
                }
                ResetError();
                msg="Item Popped";
            }
            return rval;
        }

        public string Peek(){
            string rval="";
            if (isEmpty) {
                err=true;
                msg= "Error - Stack Empty";
            } else {
                rval=stack[head];
                ResetError();
                msg="Item Peeked";
            }
            return rval;
        }

        public void Push(string newItem){
            
            if (isFull) {
                err=true; 
                msg= "Error - Stack Overflow";
            } else {
                head++;
                stack[head]=newItem;
                if (head==maxSize-1) {
                    isFull=true;
                }
                isEmpty=false;
                ResetError();
                msg="Item pushed";
            }    
                
        }

        public void PrintStack(){
            Console.WriteLine("--Stack-------");
            if (isEmpty) {
                Console.WriteLine("Empty");
            } else {
                for (int i=head; i>=0; i--) {
                    Console.WriteLine($"{i}:{stack[i]}");
                }
            }
            Console.WriteLine("-------------");
            return;
        }
        private void ResetError(){
            err=false;;
            msg="";
        }
    } 

    
}

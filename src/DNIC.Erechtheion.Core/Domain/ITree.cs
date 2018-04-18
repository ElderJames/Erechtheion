using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	//
	// Summary:
	//     树形结构接口
	public interface ITree<T>
	{
		//
		// Summary:
		//     是否是根级节点
		bool IsRoot { get; }
		//
		// Summary:
		//     是否是叶子级节点
		bool IsLeaf { get; }
		//
		// Summary:
		//     上级节点
		T ParentNode { get; }
		//
		// Summary:
		//     下级节点集
		ICollection<T> ChildNodes { get; }
	}
}

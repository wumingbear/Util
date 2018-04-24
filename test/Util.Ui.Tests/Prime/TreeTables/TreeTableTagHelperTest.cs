﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Prime.TreeTables.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Prime.TreeTables {
    /// <summary>
    /// 树型表格测试
    /// </summary>
    public class TreeTableTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 树型表格
        /// </summary>
        private readonly TreeTableTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TreeTableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TreeTableTagHelper();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();  
            result.Append( "<p-tree-table #id=\"\" key=\"id\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #a=\"\" key=\"a\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" [(queryParam)]=\"a\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试基地址
        /// </summary>
        [Fact]
        public void TestBaseUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.BaseUrl, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" baseUrl=\"a\" key=\"id\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" url=\"a\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestDeleteUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.DeleteUrl, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" deleteUrl=\"a\" key=\"id\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试多选
        /// </summary>
        [Fact]
        public void TestSelectionMode_Multiple() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectionMode, SelectionMode.Multiple } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" selectionMode=\"checkbox\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单选
        /// </summary>
        [Fact]
        public void TestSelectionMode_Single() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectionMode, SelectionMode.Single } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" selectionMode=\"single\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试仅能选叶节点
        /// </summary>
        [Fact]
        public void TestSelectionMode_SingleLeafOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectionMode, SelectionMode.SingleLeafOnly } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" selectionMode=\"single\" [leafOnly]=\"true\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动加载
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoLoad, false } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" [autoLoad]=\"false\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页长度列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions() {
            var attributes = new TagHelperAttributeList { { UiConst.PageSizeOptions, "1,2" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" [pageSizeOptions]=\"[1,2]\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页长度列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions_2() {
            var attributes = new TagHelperAttributeList { { UiConst.PageSizeOptions, "[1,2]" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" [pageSizeOptions]=\"[1,2]\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中节点
        /// </summary>
        [Fact]
        public void TestSelection() {
            var attributes = new TagHelperAttributeList { { UiConst.Selection, "a" } };
            var result = new String();
            result.Append( "<p-tree-table #id=\"\" key=\"id\" [(selection)]=\"a\">" );
            result.Append( "</p-tree-table>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
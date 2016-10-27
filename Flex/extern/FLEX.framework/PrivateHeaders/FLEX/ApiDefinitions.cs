using System;
using CoreGraphics;
using FLEX;
using Foundation;
using ObjCRuntime;
using UIKit;

// @interface FLEXManager : NSObject
[BaseType (typeof(NSObject))]
interface FLEXManager
{
	// +(instancetype)sharedManager;
	[Static]
	[Export ("sharedManager")]
	FLEXManager SharedManager ();

	// @property (readonly, nonatomic) BOOL isHidden;
	[Export ("isHidden")]
	bool IsHidden { get; }

	// -(void)showExplorer;
	[Export ("showExplorer")]
	void ShowExplorer ();

	// -(void)hideExplorer;
	[Export ("hideExplorer")]
	void HideExplorer ();

	// -(void)toggleExplorer;
	[Export ("toggleExplorer")]
	void ToggleExplorer ();

	// @property (getter = isNetworkDebuggingEnabled, assign, nonatomic) BOOL networkDebuggingEnabled;
	[Export ("networkDebuggingEnabled")]
	bool NetworkDebuggingEnabled { [Bind ("isNetworkDebuggingEnabled")] get; set; }

	// @property (assign, nonatomic) NSUInteger networkResponseCacheByteLimit;
	[Export ("networkResponseCacheByteLimit")]
	nuint NetworkResponseCacheByteLimit { get; set; }

	// @property (assign, nonatomic) BOOL simulatorShortcutsEnabled;
	[Export ("simulatorShortcutsEnabled")]
	bool SimulatorShortcutsEnabled { get; set; }

	// -(void)registerSimulatorShortcutWithKey:(NSString *)key modifiers:(UIKeyModifierFlags)modifiers action:(dispatch_block_t)action description:(NSString *)description;
	[Export ("registerSimulatorShortcutWithKey:modifiers:action:description:")]
	void RegisterSimulatorShortcutWithKey (string key, UIKeyModifierFlags modifiers, dispatch_block_t action, string description);

	// -(void)registerGlobalEntryWithName:(NSString *)entryName objectFutureBlock:(id (^)(void))objectFutureBlock;
	[Export ("registerGlobalEntryWithName:objectFutureBlock:")]
	void RegisterGlobalEntryWithName (string entryName, Func<NSObject> objectFutureBlock);

	// -(void)registerGlobalEntryWithName:(NSString *)entryName viewControllerFutureBlock:(UIViewController *(^)(void))viewControllerFutureBlock;
	[Export ("registerGlobalEntryWithName:viewControllerFutureBlock:")]
	void RegisterGlobalEntryWithName (string entryName, Func<UIViewController> viewControllerFutureBlock);
}

// @interface FLEXArgumentInputView : UIView
[BaseType (typeof(UIView))]
interface FLEXArgumentInputView
{
	// -(instancetype)initWithArgumentTypeEncoding:(const char *)typeEncoding;
	[Export ("initWithArgumentTypeEncoding:")]
	unsafe IntPtr Constructor (sbyte* typeEncoding);

	// @property (copy, nonatomic) NSString * title;
	[Export ("title")]
	string Title { get; set; }

	// @property (nonatomic) id inputValue;
	[Export ("inputValue", ArgumentSemantic.Assign)]
	NSObject InputValue { get; set; }

	// @property (assign, nonatomic) FLEXArgumentInputViewSize targetSize;
	[Export ("targetSize", ArgumentSemantic.Assign)]
	FLEXArgumentInputViewSize TargetSize { get; set; }

	[Wrap ("WeakDelegate")]
	FLEXArgumentInputViewDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FLEXArgumentInputViewDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (readonly, nonatomic) BOOL inputViewIsFirstResponder;
	[Export ("inputViewIsFirstResponder")]
	bool InputViewIsFirstResponder { get; }

	// +(BOOL)supportsObjCType:(const char *)type withCurrentValue:(id)value;
	[Static]
	[Export ("supportsObjCType:withCurrentValue:")]
	unsafe bool SupportsObjCType (sbyte* type, NSObject value);

	// @property (readonly, nonatomic, strong) UILabel * titleLabel;
	[Export ("titleLabel", ArgumentSemantic.Strong)]
	UILabel TitleLabel { get; }

	// @property (readonly, nonatomic, strong) NSString * typeEncoding;
	[Export ("typeEncoding", ArgumentSemantic.Strong)]
	string TypeEncoding { get; }

	// @property (readonly, nonatomic) CGFloat topInputFieldVerticalLayoutGuide;
	[Export ("topInputFieldVerticalLayoutGuide")]
	nfloat TopInputFieldVerticalLayoutGuide { get; }
}

// @protocol FLEXArgumentInputViewDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXArgumentInputViewDelegate
{
	// @required -(void)argumentInputViewValueDidChange:(FLEXArgumentInputView *)argumentInputView;
	[Abstract]
	[Export ("argumentInputViewValueDidChange:")]
	void ArgumentInputViewValueDidChange (FLEXArgumentInputView argumentInputView);
}

// @interface FLEXArgumentInputColorView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputColorView
{
}

// @interface FLEXArgumentInputDateView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputDateView
{
}

// @interface FLEXArgumentInputTextView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputTextView
{
	// @property (readonly, nonatomic, strong) UITextView * inputTextView;
	[Export ("inputTextView", ArgumentSemantic.Strong)]
	UITextView InputTextView { get; }
}

// @interface FLEXArgumentInputFontsPickerView : FLEXArgumentInputTextView <UIPickerViewDataSource, UIPickerViewDelegate>
[BaseType (typeof(FLEXArgumentInputTextView))]
interface FLEXArgumentInputFontsPickerView : IUIPickerViewDataSource, IUIPickerViewDelegate
{
}

// @interface FLEXArgumentInputFontView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputFontView
{
}

// @interface FLEXArgumentInputJSONObjectView : FLEXArgumentInputTextView
[BaseType (typeof(FLEXArgumentInputTextView))]
interface FLEXArgumentInputJSONObjectView
{
}

// @interface FLEXArgumentInputNotSupportedView : FLEXArgumentInputTextView
[BaseType (typeof(FLEXArgumentInputTextView))]
interface FLEXArgumentInputNotSupportedView
{
}

// @interface FLEXArgumentInputNumberView : FLEXArgumentInputTextView
[BaseType (typeof(FLEXArgumentInputTextView))]
interface FLEXArgumentInputNumberView
{
}

// @interface FLEXArgumentInputStringView : FLEXArgumentInputTextView
[BaseType (typeof(FLEXArgumentInputTextView))]
interface FLEXArgumentInputStringView
{
}

// @interface FLEXArgumentInputStructView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputStructView
{
}

// @interface FLEXArgumentInputSwitchView : FLEXArgumentInputView
[BaseType (typeof(FLEXArgumentInputView))]
interface FLEXArgumentInputSwitchView
{
}

// @interface FLEXArgumentInputViewFactory : NSObject
[BaseType (typeof(NSObject))]
interface FLEXArgumentInputViewFactory
{
	// +(FLEXArgumentInputView *)argumentInputViewForTypeEncoding:(const char *)typeEncoding;
	[Static]
	[Export ("argumentInputViewForTypeEncoding:")]
	unsafe FLEXArgumentInputView ArgumentInputViewForTypeEncoding (sbyte* typeEncoding);

	// +(FLEXArgumentInputView *)argumentInputViewForTypeEncoding:(const char *)typeEncoding currentValue:(id)currentValue;
	[Static]
	[Export ("argumentInputViewForTypeEncoding:currentValue:")]
	unsafe FLEXArgumentInputView ArgumentInputViewForTypeEncoding (sbyte* typeEncoding, NSObject currentValue);

	// +(BOOL)canEditFieldWithTypeEncoding:(const char *)typeEncoding currentValue:(id)currentValue;
	[Static]
	[Export ("canEditFieldWithTypeEncoding:currentValue:")]
	unsafe bool CanEditFieldWithTypeEncoding (sbyte* typeEncoding, NSObject currentValue);
}

// @interface FLEXObjectExplorerViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXObjectExplorerViewController
{
	// @property (nonatomic, strong) id object;
	[Export ("object", ArgumentSemantic.Strong)]
	NSObject Object { get; set; }

	// -(NSString *)customSectionTitle;
	[Export ("customSectionTitle")]
	[Verify (MethodToProperty)]
	string CustomSectionTitle { get; }

	// -(NSArray *)customSectionRowCookies;
	[Export ("customSectionRowCookies")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] CustomSectionRowCookies { get; }

	// -(NSString *)customSectionTitleForRowCookie:(id)rowCookie;
	[Export ("customSectionTitleForRowCookie:")]
	string CustomSectionTitleForRowCookie (NSObject rowCookie);

	// -(NSString *)customSectionSubtitleForRowCookie:(id)rowCookie;
	[Export ("customSectionSubtitleForRowCookie:")]
	string CustomSectionSubtitleForRowCookie (NSObject rowCookie);

	// -(BOOL)customSectionCanDrillIntoRowWithCookie:(id)rowCookie;
	[Export ("customSectionCanDrillIntoRowWithCookie:")]
	bool CustomSectionCanDrillIntoRowWithCookie (NSObject rowCookie);

	// -(UIViewController *)customSectionDrillInViewControllerForRowCookie:(id)rowCookie;
	[Export ("customSectionDrillInViewControllerForRowCookie:")]
	UIViewController CustomSectionDrillInViewControllerForRowCookie (NSObject rowCookie);

	// -(BOOL)canHaveInstanceState;
	[Export ("canHaveInstanceState")]
	[Verify (MethodToProperty)]
	bool CanHaveInstanceState { get; }

	// -(BOOL)canCallInstanceMethods;
	[Export ("canCallInstanceMethods")]
	[Verify (MethodToProperty)]
	bool CanCallInstanceMethods { get; }

	// -(BOOL)shouldShowDescription;
	[Export ("shouldShowDescription")]
	[Verify (MethodToProperty)]
	bool ShouldShowDescription { get; }

	// -(NSArray *)possibleExplorerSections;
	[Export ("possibleExplorerSections")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] PossibleExplorerSections { get; }
}

// @interface FLEXArrayExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXArrayExplorerViewController
{
}

// @interface FLEXClassesTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXClassesTableViewController
{
	// @property (copy, nonatomic) NSString * binaryImageName;
	[Export ("binaryImageName")]
	string BinaryImageName { get; set; }
}

// @interface FLEXClassExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXClassExplorerViewController
{
}

// @interface FLEXFieldEditorViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface FLEXFieldEditorViewController
{
	// -(id)initWithTarget:(id)target;
	[Export ("initWithTarget:")]
	IntPtr Constructor (NSObject target);

	// @property (readonly, nonatomic) FLEXArgumentInputView * firstInputView;
	[Export ("firstInputView")]
	FLEXArgumentInputView FirstInputView { get; }

	// @property (readonly, nonatomic, strong) id target;
	[Export ("target", ArgumentSemantic.Strong)]
	NSObject Target { get; }

	// @property (readonly, nonatomic, strong) FLEXFieldEditorView * fieldEditorView;
	[Export ("fieldEditorView", ArgumentSemantic.Strong)]
	FLEXFieldEditorView FieldEditorView { get; }

	// @property (readonly, nonatomic, strong) UIBarButtonItem * setterButton;
	[Export ("setterButton", ArgumentSemantic.Strong)]
	UIBarButtonItem SetterButton { get; }

	// -(void)actionButtonPressed:(id)sender;
	[Export ("actionButtonPressed:")]
	void ActionButtonPressed (NSObject sender);

	// -(NSString *)titleForActionButton;
	[Export ("titleForActionButton")]
	[Verify (MethodToProperty)]
	string TitleForActionButton { get; }
}

// @interface FLEXDefaultEditorViewController : FLEXFieldEditorViewController
[BaseType (typeof(FLEXFieldEditorViewController))]
interface FLEXDefaultEditorViewController
{
	// -(id)initWithDefaults:(NSUserDefaults *)defaults key:(NSString *)key;
	[Export ("initWithDefaults:key:")]
	IntPtr Constructor (NSUserDefaults defaults, string key);

	// +(BOOL)canEditDefaultWithValue:(id)currentValue;
	[Static]
	[Export ("canEditDefaultWithValue:")]
	bool CanEditDefaultWithValue (NSObject currentValue);
}

// @interface FLEXDefaultsExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXDefaultsExplorerViewController
{
}

// @interface FLEXDictionaryExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXDictionaryExplorerViewController
{
}

// @interface FLEXFieldEditorView : UIView
[BaseType (typeof(UIView))]
interface FLEXFieldEditorView
{
	// @property (copy, nonatomic) NSString * targetDescription;
	[Export ("targetDescription")]
	string TargetDescription { get; set; }

	// @property (copy, nonatomic) NSString * fieldDescription;
	[Export ("fieldDescription")]
	string FieldDescription { get; set; }

	// @property (nonatomic, strong) NSArray * argumentInputViews;
	[Export ("argumentInputViews", ArgumentSemantic.Strong)]
	[Verify (StronglyTypedNSArray)]
	NSObject[] ArgumentInputViews { get; set; }
}

// @protocol FLEXFileBrowserFileOperationControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXFileBrowserFileOperationControllerDelegate
{
	// @required -(void)fileOperationControllerDidDismiss:(id<FLEXFileBrowserFileOperationController>)controller;
	[Abstract]
	[Export ("fileOperationControllerDidDismiss:")]
	void FileOperationControllerDidDismiss (FLEXFileBrowserFileOperationController controller);
}

// @protocol FLEXFileBrowserFileOperationController <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXFileBrowserFileOperationController
{
	[Wrap ("WeakDelegate"), Abstract]
	FLEXFileBrowserFileOperationControllerDelegate Delegate { get; set; }

	// @required @property (nonatomic, weak) id<FLEXFileBrowserFileOperationControllerDelegate> delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @required -(instancetype)initWithPath:(NSString *)path;
	[Abstract]
	[Export ("initWithPath:")]
	IntPtr Constructor (string path);

	// @required -(void)show;
	[Abstract]
	[Export ("show")]
	void Show ();
}

// @interface FLEXFileBrowserFileDeleteOperationController : NSObject <FLEXFileBrowserFileOperationController>
[BaseType (typeof(NSObject))]
interface FLEXFileBrowserFileDeleteOperationController : IFLEXFileBrowserFileOperationController
{
}

// @interface FLEXFileBrowserFileRenameOperationController : NSObject <FLEXFileBrowserFileOperationController>
[BaseType (typeof(NSObject))]
interface FLEXFileBrowserFileRenameOperationController : IFLEXFileBrowserFileOperationController
{
}

// @interface FLEXFileBrowserSearchOperation : NSOperation
[BaseType (typeof(NSOperation))]
interface FLEXFileBrowserSearchOperation
{
	[Wrap ("WeakDelegate")]
	FLEXFileBrowserSearchOperationDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FLEXFileBrowserSearchOperationDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(id)initWithPath:(NSString *)currentPath searchString:(NSString *)searchString;
	[Export ("initWithPath:searchString:")]
	IntPtr Constructor (string currentPath, string searchString);
}

// @protocol FLEXFileBrowserSearchOperationDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXFileBrowserSearchOperationDelegate
{
	// @required -(void)fileBrowserSearchOperationResult:(NSArray *)searchResult size:(uint64_t)size;
	[Abstract]
	[Export ("fileBrowserSearchOperationResult:size:")]
	[Verify (StronglyTypedNSArray)]
	void Size (NSObject[] searchResult, ulong size);
}

// @interface FLEXFileBrowserTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXFileBrowserTableViewController
{
	// -(id)initWithPath:(NSString *)path;
	[Export ("initWithPath:")]
	IntPtr Constructor (string path);
}

// @interface FLEXGlobalsTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXGlobalsTableViewController
{
	[Wrap ("WeakDelegate")]
	FLEXGlobalsTableViewControllerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FLEXGlobalsTableViewControllerDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// +(void)setApplicationWindow:(UIWindow *)applicationWindow;
	[Static]
	[Export ("setApplicationWindow:")]
	void SetApplicationWindow (UIWindow applicationWindow);
}

// @protocol FLEXGlobalsTableViewControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXGlobalsTableViewControllerDelegate
{
	// @required -(void)globalsViewControllerDidFinish:(FLEXGlobalsTableViewController *)globalsViewController;
	[Abstract]
	[Export ("globalsViewControllerDidFinish:")]
	void GlobalsViewControllerDidFinish (FLEXGlobalsTableViewController globalsViewController);
}

// typedef NSString * (^FLEXGlobalsTableViewControllerEntryNameFuture)();
delegate string FLEXGlobalsTableViewControllerEntryNameFuture ();

// typedef UIViewController * (^FLEXGlobalsTableViewControllerViewControllerFuture)();
delegate UIViewController FLEXGlobalsTableViewControllerViewControllerFuture ();

// @interface FLEXGlobalsTableViewControllerEntry : NSObject
[BaseType (typeof(NSObject))]
interface FLEXGlobalsTableViewControllerEntry
{
	// @property (readonly, copy, nonatomic) FLEXGlobalsTableViewControllerEntryNameFuture entryNameFuture;
	[Export ("entryNameFuture", ArgumentSemantic.Copy)]
	FLEXGlobalsTableViewControllerEntryNameFuture EntryNameFuture { get; }

	// @property (readonly, copy, nonatomic) FLEXGlobalsTableViewControllerViewControllerFuture viewControllerFuture;
	[Export ("viewControllerFuture", ArgumentSemantic.Copy)]
	FLEXGlobalsTableViewControllerViewControllerFuture ViewControllerFuture { get; }

	// +(instancetype)entryWithNameFuture:(FLEXGlobalsTableViewControllerEntryNameFuture)nameFuture viewControllerFuture:(FLEXGlobalsTableViewControllerViewControllerFuture)viewControllerFuture;
	[Static]
	[Export ("entryWithNameFuture:viewControllerFuture:")]
	FLEXGlobalsTableViewControllerEntry EntryWithNameFuture (FLEXGlobalsTableViewControllerEntryNameFuture nameFuture, FLEXGlobalsTableViewControllerViewControllerFuture viewControllerFuture);
}

// typedef void (^flex_object_enumeration_block_t)(id, Class);
delegate void flex_object_enumeration_block_t (NSObject arg0, Class arg1);

// @interface FLEXHeapEnumerator : NSObject
[BaseType (typeof(NSObject))]
interface FLEXHeapEnumerator
{
	// +(void)enumerateLiveObjectsUsingBlock:(flex_object_enumeration_block_t)block;
	[Static]
	[Export ("enumerateLiveObjectsUsingBlock:")]
	void EnumerateLiveObjectsUsingBlock (flex_object_enumeration_block_t block);
}

// @interface FLEXHierarchyTableViewCell : UITableViewCell
[BaseType (typeof(UITableViewCell))]
interface FLEXHierarchyTableViewCell
{
	// -(id)initWithReuseIdentifier:(NSString *)reuseIdentifier;
	[Export ("initWithReuseIdentifier:")]
	IntPtr Constructor (string reuseIdentifier);

	// @property (assign, nonatomic) NSInteger viewDepth;
	[Export ("viewDepth")]
	nint ViewDepth { get; set; }

	// @property (nonatomic, strong) UIColor * viewColor;
	[Export ("viewColor", ArgumentSemantic.Strong)]
	UIColor ViewColor { get; set; }
}

// @interface FLEXHierarchyTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXHierarchyTableViewController
{
	// -(id)initWithViews:(NSArray *)allViews viewsAtTap:(NSArray *)viewsAtTap selectedView:(UIView *)selectedView depths:(NSDictionary *)depthsForViews;
	[Export ("initWithViews:viewsAtTap:selectedView:depths:")]
	[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
	IntPtr Constructor (NSObject[] allViews, NSObject[] viewsAtTap, UIView selectedView, NSDictionary depthsForViews);

	[Wrap ("WeakDelegate")]
	FLEXHierarchyTableViewControllerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FLEXHierarchyTableViewControllerDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }
}

// @protocol FLEXHierarchyTableViewControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FLEXHierarchyTableViewControllerDelegate
{
	// @required -(void)hierarchyViewController:(FLEXHierarchyTableViewController *)hierarchyViewController didFinishWithSelectedView:(UIView *)selectedView;
	[Abstract]
	[Export ("hierarchyViewController:didFinishWithSelectedView:")]
	void DidFinishWithSelectedView (FLEXHierarchyTableViewController hierarchyViewController, UIView selectedView);
}

// @interface FLEXImageExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXImageExplorerViewController
{
}

// @interface FLEXImagePreviewViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface FLEXImagePreviewViewController
{
	// -(id)initWithImage:(UIImage *)image;
	[Export ("initWithImage:")]
	IntPtr Constructor (UIImage image);
}

// @interface FLEXInstancesTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXInstancesTableViewController
{
	// +(instancetype)instancesTableViewControllerForClassName:(NSString *)className;
	[Static]
	[Export ("instancesTableViewControllerForClassName:")]
	FLEXInstancesTableViewController InstancesTableViewControllerForClassName (string className);

	// +(instancetype)instancesTableViewControllerForInstancesReferencingObject:(id)object;
	[Static]
	[Export ("instancesTableViewControllerForInstancesReferencingObject:")]
	FLEXInstancesTableViewController InstancesTableViewControllerForInstancesReferencingObject (NSObject @object);
}

// @interface FLEXIvarEditorViewController : FLEXFieldEditorViewController
[BaseType (typeof(FLEXFieldEditorViewController))]
interface FLEXIvarEditorViewController
{
	// -(id)initWithTarget:(id)target ivar:(Ivar)ivar;
	[Export ("initWithTarget:ivar:")]
	unsafe IntPtr Constructor (NSObject target, Ivar* ivar);

	// +(BOOL)canEditIvar:(Ivar)ivar currentValue:(id)value;
	[Static]
	[Export ("canEditIvar:currentValue:")]
	unsafe bool CanEditIvar (Ivar* ivar, NSObject value);
}

// @interface FLEXKeyboardHelpViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface FLEXKeyboardHelpViewController
{
}

// @interface FLEXLayerExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXLayerExplorerViewController
{
}

// @interface FLEXLibrariesTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXLibrariesTableViewController
{
}

// @interface FLEXLiveObjectsTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXLiveObjectsTableViewController
{
}

// @interface FLEXMethodCallingViewController : FLEXFieldEditorViewController
[BaseType (typeof(FLEXFieldEditorViewController))]
interface FLEXMethodCallingViewController
{
	// -(id)initWithTarget:(id)target method:(Method)method;
	[Export ("initWithTarget:method:")]
	unsafe IntPtr Constructor (NSObject target, Method* method);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const kFLEXMultilineTableViewCellIdentifier;
	[Field ("kFLEXMultilineTableViewCellIdentifier", "__Internal")]
	NSString kFLEXMultilineTableViewCellIdentifier { get; }
}

// @interface FLEXMultilineTableViewCell : UITableViewCell
[BaseType (typeof(UITableViewCell))]
interface FLEXMultilineTableViewCell
{
	// +(CGFloat)preferredHeightWithAttributedText:(NSAttributedString *)attributedText inTableViewWidth:(CGFloat)tableViewWidth style:(UITableViewStyle)style showsAccessory:(BOOL)showsAccessory;
	[Static]
	[Export ("preferredHeightWithAttributedText:inTableViewWidth:style:showsAccessory:")]
	nfloat PreferredHeightWithAttributedText (NSAttributedString attributedText, nfloat tableViewWidth, UITableViewStyle style, bool showsAccessory);
}

// @interface FLEXNetworkHistoryTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXNetworkHistoryTableViewController
{
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const kFLEXNetworkObserverEnabledStateChangedNotification;
	[Field ("kFLEXNetworkObserverEnabledStateChangedNotification", "__Internal")]
	NSString kFLEXNetworkObserverEnabledStateChangedNotification { get; }
}

// @interface FLEXNetworkObserver : NSObject
[BaseType (typeof(NSObject))]
interface FLEXNetworkObserver
{
	// +(void)setEnabled:(BOOL)enabled;
	[Static]
	[Export ("setEnabled:")]
	void SetEnabled (bool enabled);

	// +(BOOL)isEnabled;
	[Static]
	[Export ("isEnabled")]
	[Verify (MethodToProperty)]
	bool IsEnabled { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const kFLEXNetworkRecorderNewTransactionNotification;
	[Field ("kFLEXNetworkRecorderNewTransactionNotification", "__Internal")]
	NSString kFLEXNetworkRecorderNewTransactionNotification { get; }

	// extern NSString *const kFLEXNetworkRecorderTransactionUpdatedNotification;
	[Field ("kFLEXNetworkRecorderTransactionUpdatedNotification", "__Internal")]
	NSString kFLEXNetworkRecorderTransactionUpdatedNotification { get; }

	// extern NSString *const kFLEXNetworkRecorderUserInfoTransactionKey;
	[Field ("kFLEXNetworkRecorderUserInfoTransactionKey", "__Internal")]
	NSString kFLEXNetworkRecorderUserInfoTransactionKey { get; }

	// extern NSString *const kFLEXNetworkRecorderTransactionsClearedNotification;
	[Field ("kFLEXNetworkRecorderTransactionsClearedNotification", "__Internal")]
	NSString kFLEXNetworkRecorderTransactionsClearedNotification { get; }
}

// @interface FLEXNetworkRecorder : NSObject
[BaseType (typeof(NSObject))]
interface FLEXNetworkRecorder
{
	// +(instancetype)defaultRecorder;
	[Static]
	[Export ("defaultRecorder")]
	FLEXNetworkRecorder DefaultRecorder ();

	// @property (assign, nonatomic) NSUInteger responseCacheByteLimit;
	[Export ("responseCacheByteLimit")]
	nuint ResponseCacheByteLimit { get; set; }

	// @property (assign, nonatomic) BOOL shouldCacheMediaResponses;
	[Export ("shouldCacheMediaResponses")]
	bool ShouldCacheMediaResponses { get; set; }

	// -(NSArray *)networkTransactions;
	[Export ("networkTransactions")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] NetworkTransactions { get; }

	// -(NSData *)cachedResponseBodyForTransaction:(FLEXNetworkTransaction *)transaction;
	[Export ("cachedResponseBodyForTransaction:")]
	NSData CachedResponseBodyForTransaction (FLEXNetworkTransaction transaction);

	// -(void)clearRecordedActivity;
	[Export ("clearRecordedActivity")]
	void ClearRecordedActivity ();

	// -(void)recordRequestWillBeSentWithRequestID:(NSString *)requestID request:(NSURLRequest *)request redirectResponse:(NSURLResponse *)redirectResponse;
	[Export ("recordRequestWillBeSentWithRequestID:request:redirectResponse:")]
	void RecordRequestWillBeSentWithRequestID (string requestID, NSUrlRequest request, NSUrlResponse redirectResponse);

	// -(void)recordResponseReceivedWithRequestID:(NSString *)requestID response:(NSURLResponse *)response;
	[Export ("recordResponseReceivedWithRequestID:response:")]
	void RecordResponseReceivedWithRequestID (string requestID, NSUrlResponse response);

	// -(void)recordDataReceivedWithRequestID:(NSString *)requestID dataLength:(int64_t)dataLength;
	[Export ("recordDataReceivedWithRequestID:dataLength:")]
	void RecordDataReceivedWithRequestID (string requestID, long dataLength);

	// -(void)recordLoadingFinishedWithRequestID:(NSString *)requestID responseBody:(NSData *)responseBody;
	[Export ("recordLoadingFinishedWithRequestID:responseBody:")]
	void RecordLoadingFinishedWithRequestID (string requestID, NSData responseBody);

	// -(void)recordLoadingFailedWithRequestID:(NSString *)requestID error:(NSError *)error;
	[Export ("recordLoadingFailedWithRequestID:error:")]
	void RecordLoadingFailedWithRequestID (string requestID, NSError error);

	// -(void)recordMechanism:(NSString *)mechanism forRequestID:(NSString *)requestID;
	[Export ("recordMechanism:forRequestID:")]
	void RecordMechanism (string mechanism, string requestID);
}

// @interface FLEXNetworkSettingsTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXNetworkSettingsTableViewController
{
}

// @interface FLEXNetworkTransaction : NSObject
[BaseType (typeof(NSObject))]
interface FLEXNetworkTransaction
{
	// @property (copy, nonatomic) NSString * requestID;
	[Export ("requestID")]
	string RequestID { get; set; }

	// @property (nonatomic, strong) NSURLRequest * request;
	[Export ("request", ArgumentSemantic.Strong)]
	NSUrlRequest Request { get; set; }

	// @property (nonatomic, strong) NSURLResponse * response;
	[Export ("response", ArgumentSemantic.Strong)]
	NSUrlResponse Response { get; set; }

	// @property (copy, nonatomic) NSString * requestMechanism;
	[Export ("requestMechanism")]
	string RequestMechanism { get; set; }

	// @property (assign, nonatomic) FLEXNetworkTransactionState transactionState;
	[Export ("transactionState", ArgumentSemantic.Assign)]
	FLEXNetworkTransactionState TransactionState { get; set; }

	// @property (nonatomic, strong) NSError * error;
	[Export ("error", ArgumentSemantic.Strong)]
	NSError Error { get; set; }

	// @property (nonatomic, strong) NSDate * startTime;
	[Export ("startTime", ArgumentSemantic.Strong)]
	NSDate StartTime { get; set; }

	// @property (assign, nonatomic) NSTimeInterval latency;
	[Export ("latency")]
	double Latency { get; set; }

	// @property (assign, nonatomic) NSTimeInterval duration;
	[Export ("duration")]
	double Duration { get; set; }

	// @property (assign, nonatomic) int64_t receivedDataLength;
	[Export ("receivedDataLength")]
	long ReceivedDataLength { get; set; }

	// @property (nonatomic, strong) UIImage * responseThumbnail;
	[Export ("responseThumbnail", ArgumentSemantic.Strong)]
	UIImage ResponseThumbnail { get; set; }

	// @property (readonly, nonatomic, strong) NSData * cachedRequestBody;
	[Export ("cachedRequestBody", ArgumentSemantic.Strong)]
	NSData CachedRequestBody { get; }

	// +(NSString *)readableStringFromTransactionState:(FLEXNetworkTransactionState)state;
	[Static]
	[Export ("readableStringFromTransactionState:")]
	string ReadableStringFromTransactionState (FLEXNetworkTransactionState state);
}

// @interface FLEXNetworkTransactionDetailTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXNetworkTransactionDetailTableViewController
{
	// @property (nonatomic, strong) FLEXNetworkTransaction * transaction;
	[Export ("transaction", ArgumentSemantic.Strong)]
	FLEXNetworkTransaction Transaction { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const kFLEXNetworkTransactionCellIdentifier;
	[Field ("kFLEXNetworkTransactionCellIdentifier", "__Internal")]
	NSString kFLEXNetworkTransactionCellIdentifier { get; }
}

// @interface FLEXNetworkTransactionTableViewCell : UITableViewCell
[BaseType (typeof(UITableViewCell))]
interface FLEXNetworkTransactionTableViewCell
{
	// @property (nonatomic, strong) FLEXNetworkTransaction * transaction;
	[Export ("transaction", ArgumentSemantic.Strong)]
	FLEXNetworkTransaction Transaction { get; set; }

	// +(CGFloat)preferredCellHeight;
	[Static]
	[Export ("preferredCellHeight")]
	[Verify (MethodToProperty)]
	nfloat PreferredCellHeight { get; }
}

// @interface FLEXObjectExplorerFactory : NSObject
[BaseType (typeof(NSObject))]
interface FLEXObjectExplorerFactory
{
	// +(FLEXObjectExplorerViewController *)explorerViewControllerForObject:(id)object;
	[Static]
	[Export ("explorerViewControllerForObject:")]
	FLEXObjectExplorerViewController ExplorerViewControllerForObject (NSObject @object);
}

// @interface FLEXPropertyEditorViewController : FLEXFieldEditorViewController
[BaseType (typeof(FLEXFieldEditorViewController))]
interface FLEXPropertyEditorViewController
{
	// -(id)initWithTarget:(id)target property:(objc_property_t)property;
	[Export ("initWithTarget:property:")]
	unsafe IntPtr Constructor (NSObject target, objc_property_t* property);

	// +(BOOL)canEditProperty:(objc_property_t)property currentValue:(id)value;
	[Static]
	[Export ("canEditProperty:currentValue:")]
	unsafe bool CanEditProperty (objc_property_t* property, NSObject value);
}

// @interface FLEXResources : NSObject
[BaseType (typeof(NSObject))]
interface FLEXResources
{
	// +(UIImage *)closeIcon;
	[Static]
	[Export ("closeIcon")]
	[Verify (MethodToProperty)]
	UIImage CloseIcon { get; }

	// +(UIImage *)dragHandle;
	[Static]
	[Export ("dragHandle")]
	[Verify (MethodToProperty)]
	UIImage DragHandle { get; }

	// +(UIImage *)globeIcon;
	[Static]
	[Export ("globeIcon")]
	[Verify (MethodToProperty)]
	UIImage GlobeIcon { get; }

	// +(UIImage *)hierarchyIndentPattern;
	[Static]
	[Export ("hierarchyIndentPattern")]
	[Verify (MethodToProperty)]
	UIImage HierarchyIndentPattern { get; }

	// +(UIImage *)listIcon;
	[Static]
	[Export ("listIcon")]
	[Verify (MethodToProperty)]
	UIImage ListIcon { get; }

	// +(UIImage *)moveIcon;
	[Static]
	[Export ("moveIcon")]
	[Verify (MethodToProperty)]
	UIImage MoveIcon { get; }

	// +(UIImage *)selectIcon;
	[Static]
	[Export ("selectIcon")]
	[Verify (MethodToProperty)]
	UIImage SelectIcon { get; }

	// +(UIImage *)jsonIcon;
	[Static]
	[Export ("jsonIcon")]
	[Verify (MethodToProperty)]
	UIImage JsonIcon { get; }

	// +(UIImage *)textPlainIcon;
	[Static]
	[Export ("textPlainIcon")]
	[Verify (MethodToProperty)]
	UIImage TextPlainIcon { get; }

	// +(UIImage *)htmlIcon;
	[Static]
	[Export ("htmlIcon")]
	[Verify (MethodToProperty)]
	UIImage HtmlIcon { get; }

	// +(UIImage *)audioIcon;
	[Static]
	[Export ("audioIcon")]
	[Verify (MethodToProperty)]
	UIImage AudioIcon { get; }

	// +(UIImage *)jsIcon;
	[Static]
	[Export ("jsIcon")]
	[Verify (MethodToProperty)]
	UIImage JsIcon { get; }

	// +(UIImage *)plistIcon;
	[Static]
	[Export ("plistIcon")]
	[Verify (MethodToProperty)]
	UIImage PlistIcon { get; }

	// +(UIImage *)textIcon;
	[Static]
	[Export ("textIcon")]
	[Verify (MethodToProperty)]
	UIImage TextIcon { get; }

	// +(UIImage *)videoIcon;
	[Static]
	[Export ("videoIcon")]
	[Verify (MethodToProperty)]
	UIImage VideoIcon { get; }

	// +(UIImage *)xmlIcon;
	[Static]
	[Export ("xmlIcon")]
	[Verify (MethodToProperty)]
	UIImage XmlIcon { get; }

	// +(UIImage *)binaryIcon;
	[Static]
	[Export ("binaryIcon")]
	[Verify (MethodToProperty)]
	UIImage BinaryIcon { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const unsigned int kFLEXNumberOfImplicitArgs;
	[Field ("kFLEXNumberOfImplicitArgs", "__Internal")]
	uint kFLEXNumberOfImplicitArgs { get; }

	// extern NSString *const kFLEXUtilityAttributeTypeEncoding;
	[Field ("kFLEXUtilityAttributeTypeEncoding", "__Internal")]
	NSString kFLEXUtilityAttributeTypeEncoding { get; }

	// extern NSString *const kFLEXUtilityAttributeBackingIvar;
	[Field ("kFLEXUtilityAttributeBackingIvar", "__Internal")]
	NSString kFLEXUtilityAttributeBackingIvar { get; }

	// extern NSString *const kFLEXUtilityAttributeReadOnly;
	[Field ("kFLEXUtilityAttributeReadOnly", "__Internal")]
	NSString kFLEXUtilityAttributeReadOnly { get; }

	// extern NSString *const kFLEXUtilityAttributeCopy;
	[Field ("kFLEXUtilityAttributeCopy", "__Internal")]
	NSString kFLEXUtilityAttributeCopy { get; }

	// extern NSString *const kFLEXUtilityAttributeRetain;
	[Field ("kFLEXUtilityAttributeRetain", "__Internal")]
	NSString kFLEXUtilityAttributeRetain { get; }

	// extern NSString *const kFLEXUtilityAttributeNonAtomic;
	[Field ("kFLEXUtilityAttributeNonAtomic", "__Internal")]
	NSString kFLEXUtilityAttributeNonAtomic { get; }

	// extern NSString *const kFLEXUtilityAttributeCustomGetter;
	[Field ("kFLEXUtilityAttributeCustomGetter", "__Internal")]
	NSString kFLEXUtilityAttributeCustomGetter { get; }

	// extern NSString *const kFLEXUtilityAttributeCustomSetter;
	[Field ("kFLEXUtilityAttributeCustomSetter", "__Internal")]
	NSString kFLEXUtilityAttributeCustomSetter { get; }

	// extern NSString *const kFLEXUtilityAttributeDynamic;
	[Field ("kFLEXUtilityAttributeDynamic", "__Internal")]
	NSString kFLEXUtilityAttributeDynamic { get; }

	// extern NSString *const kFLEXUtilityAttributeWeak;
	[Field ("kFLEXUtilityAttributeWeak", "__Internal")]
	NSString kFLEXUtilityAttributeWeak { get; }

	// extern NSString *const kFLEXUtilityAttributeGarbageCollectable;
	[Field ("kFLEXUtilityAttributeGarbageCollectable", "__Internal")]
	NSString kFLEXUtilityAttributeGarbageCollectable { get; }

	// extern NSString *const kFLEXUtilityAttributeOldStyleTypeEncoding;
	[Field ("kFLEXUtilityAttributeOldStyleTypeEncoding", "__Internal")]
	NSString kFLEXUtilityAttributeOldStyleTypeEncoding { get; }
}

// @interface FLEXRuntimeUtility : NSObject
[BaseType (typeof(NSObject))]
interface FLEXRuntimeUtility
{
	// +(NSString *)prettyNameForProperty:(objc_property_t)property;
	[Static]
	[Export ("prettyNameForProperty:")]
	unsafe string PrettyNameForProperty (objc_property_t* property);

	// +(NSString *)typeEncodingForProperty:(objc_property_t)property;
	[Static]
	[Export ("typeEncodingForProperty:")]
	unsafe string TypeEncodingForProperty (objc_property_t* property);

	// +(BOOL)isReadonlyProperty:(objc_property_t)property;
	[Static]
	[Export ("isReadonlyProperty:")]
	unsafe bool IsReadonlyProperty (objc_property_t* property);

	// +(SEL)setterSelectorForProperty:(objc_property_t)property;
	[Static]
	[Export ("setterSelectorForProperty:")]
	unsafe Selector SetterSelectorForProperty (objc_property_t* property);

	// +(NSString *)fullDescriptionForProperty:(objc_property_t)property;
	[Static]
	[Export ("fullDescriptionForProperty:")]
	unsafe string FullDescriptionForProperty (objc_property_t* property);

	// +(id)valueForProperty:(objc_property_t)property onObject:(id)object;
	[Static]
	[Export ("valueForProperty:onObject:")]
	unsafe NSObject ValueForProperty (objc_property_t* property, NSObject @object);

	// +(NSString *)descriptionForIvarOrPropertyValue:(id)value;
	[Static]
	[Export ("descriptionForIvarOrPropertyValue:")]
	string DescriptionForIvarOrPropertyValue (NSObject value);

	// +(void)tryAddPropertyWithName:(const char *)name attributes:(NSDictionary *)attributePairs toClass:(Class)theClass;
	[Static]
	[Export ("tryAddPropertyWithName:attributes:toClass:")]
	unsafe void TryAddPropertyWithName (sbyte* name, NSDictionary attributePairs, Class theClass);

	// +(NSString *)prettyNameForIvar:(Ivar)ivar;
	[Static]
	[Export ("prettyNameForIvar:")]
	unsafe string PrettyNameForIvar (Ivar* ivar);

	// +(id)valueForIvar:(Ivar)ivar onObject:(id)object;
	[Static]
	[Export ("valueForIvar:onObject:")]
	unsafe NSObject ValueForIvar (Ivar* ivar, NSObject @object);

	// +(void)setValue:(id)value forIvar:(Ivar)ivar onObject:(id)object;
	[Static]
	[Export ("setValue:forIvar:onObject:")]
	unsafe void SetValue (NSObject value, Ivar* ivar, NSObject @object);

	// +(NSString *)prettyNameForMethod:(Method)method isClassMethod:(BOOL)isClassMethod;
	[Static]
	[Export ("prettyNameForMethod:isClassMethod:")]
	unsafe string PrettyNameForMethod (Method* method, bool isClassMethod);

	// +(NSArray *)prettyArgumentComponentsForMethod:(Method)method;
	[Static]
	[Export ("prettyArgumentComponentsForMethod:")]
	[Verify (StronglyTypedNSArray)]
	unsafe NSObject[] PrettyArgumentComponentsForMethod (Method* method);

	// +(id)performSelector:(SEL)selector onObject:(id)object withArguments:(NSArray *)arguments error:(NSError **)error;
	[Static]
	[Export ("performSelector:onObject:withArguments:error:")]
	[Verify (StronglyTypedNSArray)]
	NSObject PerformSelector (Selector selector, NSObject @object, NSObject[] arguments, out NSError error);

	// +(NSString *)editableJSONStringForObject:(id)object;
	[Static]
	[Export ("editableJSONStringForObject:")]
	string EditableJSONStringForObject (NSObject @object);

	// +(id)objectValueFromEditableJSONString:(NSString *)string;
	[Static]
	[Export ("objectValueFromEditableJSONString:")]
	NSObject ObjectValueFromEditableJSONString (string @string);

	// +(NSValue *)valueForNumberWithObjCType:(const char *)typeEncoding fromInputString:(NSString *)inputString;
	[Static]
	[Export ("valueForNumberWithObjCType:fromInputString:")]
	unsafe NSValue ValueForNumberWithObjCType (sbyte* typeEncoding, string inputString);

	// +(void)enumerateTypesInStructEncoding:(const char *)structEncoding usingBlock:(void (^)(NSString *, const char *, NSString *, NSUInteger, NSUInteger))typeBlock;
	[Static]
	[Export ("enumerateTypesInStructEncoding:usingBlock:")]
	unsafe void EnumerateTypesInStructEncoding (sbyte* structEncoding, Action<NSString, sbyte*, NSString, nuint, nuint> typeBlock);

	// +(NSValue *)valueForPrimitivePointer:(void *)pointer objCType:(const char *)type;
	[Static]
	[Export ("valueForPrimitivePointer:objCType:")]
	unsafe NSValue ValueForPrimitivePointer (void* pointer, sbyte* type);
}

// @interface FLEXSetExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXSetExplorerViewController
{
}

// @interface FLEXSystemLogMessage : NSObject
[BaseType (typeof(NSObject))]
interface FLEXSystemLogMessage
{
	// +(instancetype)logMessageFromASLMessage:(aslmsg)aslMessage;
	[Static]
	[Export ("logMessageFromASLMessage:")]
	unsafe FLEXSystemLogMessage LogMessageFromASLMessage (aslmsg* aslMessage);

	// @property (nonatomic, strong) NSDate * date;
	[Export ("date", ArgumentSemantic.Strong)]
	NSDate Date { get; set; }

	// @property (copy, nonatomic) NSString * sender;
	[Export ("sender")]
	string Sender { get; set; }

	// @property (copy, nonatomic) NSString * messageText;
	[Export ("messageText")]
	string MessageText { get; set; }

	// @property (assign, nonatomic) long long messageID;
	[Export ("messageID")]
	long MessageID { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const kFLEXSystemLogTableViewCellIdentifier;
	[Field ("kFLEXSystemLogTableViewCellIdentifier", "__Internal")]
	NSString kFLEXSystemLogTableViewCellIdentifier { get; }
}

// @interface FLEXSystemLogTableViewCell : UITableViewCell
[BaseType (typeof(UITableViewCell))]
interface FLEXSystemLogTableViewCell
{
	// @property (nonatomic, strong) FLEXSystemLogMessage * logMessage;
	[Export ("logMessage", ArgumentSemantic.Strong)]
	FLEXSystemLogMessage LogMessage { get; set; }

	// @property (copy, nonatomic) NSString * highlightedText;
	[Export ("highlightedText")]
	string HighlightedText { get; set; }

	// +(NSString *)displayedTextForLogMessage:(FLEXSystemLogMessage *)logMessage;
	[Static]
	[Export ("displayedTextForLogMessage:")]
	string DisplayedTextForLogMessage (FLEXSystemLogMessage logMessage);

	// +(CGFloat)preferredHeightForLogMessage:(FLEXSystemLogMessage *)logMessage inWidth:(CGFloat)width;
	[Static]
	[Export ("preferredHeightForLogMessage:inWidth:")]
	nfloat PreferredHeightForLogMessage (FLEXSystemLogMessage logMessage, nfloat width);
}

// @interface FLEXSystemLogTableViewController : UITableViewController
[BaseType (typeof(UITableViewController))]
interface FLEXSystemLogTableViewController
{
}

// @interface FLEXUtility : NSObject
[BaseType (typeof(NSObject))]
interface FLEXUtility
{
	// +(UIColor *)consistentRandomColorForObject:(id)object;
	[Static]
	[Export ("consistentRandomColorForObject:")]
	UIColor ConsistentRandomColorForObject (NSObject @object);

	// +(NSString *)descriptionForView:(UIView *)view includingFrame:(BOOL)includeFrame;
	[Static]
	[Export ("descriptionForView:includingFrame:")]
	string DescriptionForView (UIView view, bool includeFrame);

	// +(NSString *)stringForCGRect:(CGRect)rect;
	[Static]
	[Export ("stringForCGRect:")]
	string StringForCGRect (CGRect rect);

	// +(UIViewController *)viewControllerForView:(UIView *)view;
	[Static]
	[Export ("viewControllerForView:")]
	UIViewController ViewControllerForView (UIView view);

	// +(UIViewController *)viewControllerForAncestralView:(UIView *)view;
	[Static]
	[Export ("viewControllerForAncestralView:")]
	UIViewController ViewControllerForAncestralView (UIView view);

	// +(NSString *)detailDescriptionForView:(UIView *)view;
	[Static]
	[Export ("detailDescriptionForView:")]
	string DetailDescriptionForView (UIView view);

	// +(UIImage *)circularImageWithColor:(UIColor *)color radius:(CGFloat)radius;
	[Static]
	[Export ("circularImageWithColor:radius:")]
	UIImage CircularImageWithColor (UIColor color, nfloat radius);

	// +(UIColor *)scrollViewGrayColor;
	[Static]
	[Export ("scrollViewGrayColor")]
	[Verify (MethodToProperty)]
	UIColor ScrollViewGrayColor { get; }

	// +(UIColor *)hierarchyIndentPatternColor;
	[Static]
	[Export ("hierarchyIndentPatternColor")]
	[Verify (MethodToProperty)]
	UIColor HierarchyIndentPatternColor { get; }

	// +(NSString *)applicationImageName;
	[Static]
	[Export ("applicationImageName")]
	[Verify (MethodToProperty)]
	string ApplicationImageName { get; }

	// +(NSString *)applicationName;
	[Static]
	[Export ("applicationName")]
	[Verify (MethodToProperty)]
	string ApplicationName { get; }

	// +(NSString *)safeDescriptionForObject:(id)object;
	[Static]
	[Export ("safeDescriptionForObject:")]
	string SafeDescriptionForObject (NSObject @object);

	// +(UIFont *)defaultFontOfSize:(CGFloat)size;
	[Static]
	[Export ("defaultFontOfSize:")]
	UIFont DefaultFontOfSize (nfloat size);

	// +(UIFont *)defaultTableViewCellLabelFont;
	[Static]
	[Export ("defaultTableViewCellLabelFont")]
	[Verify (MethodToProperty)]
	UIFont DefaultTableViewCellLabelFont { get; }

	// +(NSString *)stringByEscapingHTMLEntitiesInString:(NSString *)originalString;
	[Static]
	[Export ("stringByEscapingHTMLEntitiesInString:")]
	string StringByEscapingHTMLEntitiesInString (string originalString);

	// +(UIInterfaceOrientationMask)infoPlistSupportedInterfaceOrientationsMask;
	[Static]
	[Export ("infoPlistSupportedInterfaceOrientationsMask")]
	[Verify (MethodToProperty)]
	UIInterfaceOrientationMask InfoPlistSupportedInterfaceOrientationsMask { get; }

	// +(NSString *)searchBarPlaceholderText;
	[Static]
	[Export ("searchBarPlaceholderText")]
	[Verify (MethodToProperty)]
	string SearchBarPlaceholderText { get; }

	// +(BOOL)isImagePathExtension:(NSString *)extension;
	[Static]
	[Export ("isImagePathExtension:")]
	bool IsImagePathExtension (string extension);

	// +(UIImage *)thumbnailedImageWithMaxPixelDimension:(NSInteger)dimension fromImageData:(NSData *)data;
	[Static]
	[Export ("thumbnailedImageWithMaxPixelDimension:fromImageData:")]
	UIImage ThumbnailedImageWithMaxPixelDimension (nint dimension, NSData data);

	// +(NSString *)stringFromRequestDuration:(NSTimeInterval)duration;
	[Static]
	[Export ("stringFromRequestDuration:")]
	string StringFromRequestDuration (double duration);

	// +(NSString *)statusCodeStringFromURLResponse:(NSURLResponse *)response;
	[Static]
	[Export ("statusCodeStringFromURLResponse:")]
	string StatusCodeStringFromURLResponse (NSUrlResponse response);

	// +(NSDictionary *)dictionaryFromQuery:(NSString *)query;
	[Static]
	[Export ("dictionaryFromQuery:")]
	NSDictionary DictionaryFromQuery (string query);

	// +(NSString *)prettyJSONStringFromData:(NSData *)data;
	[Static]
	[Export ("prettyJSONStringFromData:")]
	string PrettyJSONStringFromData (NSData data);

	// +(BOOL)isValidJSONData:(NSData *)data;
	[Static]
	[Export ("isValidJSONData:")]
	bool IsValidJSONData (NSData data);

	// +(NSData *)inflatedDataFromCompressedData:(NSData *)compressedData;
	[Static]
	[Export ("inflatedDataFromCompressedData:")]
	NSData InflatedDataFromCompressedData (NSData compressedData);

	// +(NSArray *)allWindows;
	[Static]
	[Export ("allWindows")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] AllWindows { get; }

	// +(SEL)swizzledSelectorForSelector:(SEL)selector;
	[Static]
	[Export ("swizzledSelectorForSelector:")]
	Selector SwizzledSelectorForSelector (Selector selector);

	// +(BOOL)instanceRespondsButDoesNotImplementSelector:(SEL)selector class:(Class)cls;
	[Static]
	[Export ("instanceRespondsButDoesNotImplementSelector:class:")]
	bool InstanceRespondsButDoesNotImplementSelector (Selector selector, Class cls);

	// +(void)replaceImplementationOfKnownSelector:(SEL)originalSelector onClass:(Class)class withBlock:(id)block swizzledSelector:(SEL)swizzledSelector;
	[Static]
	[Export ("replaceImplementationOfKnownSelector:onClass:withBlock:swizzledSelector:")]
	void ReplaceImplementationOfKnownSelector (Selector originalSelector, Class @class, NSObject block, Selector swizzledSelector);

	// +(void)replaceImplementationOfSelector:(SEL)selector withSelector:(SEL)swizzledSelector forClass:(Class)cls withMethodDescription:(struct objc_method_description)methodDescription implementationBlock:(id)implementationBlock undefinedBlock:(id)undefinedBlock;
	[Static]
	[Export ("replaceImplementationOfSelector:withSelector:forClass:withMethodDescription:implementationBlock:undefinedBlock:")]
	void ReplaceImplementationOfSelector (Selector selector, Selector swizzledSelector, Class cls, objc_method_description methodDescription, NSObject implementationBlock, NSObject undefinedBlock);
}

// @interface FLEXViewControllerExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXViewControllerExplorerViewController
{
}

// @interface FLEXViewExplorerViewController : FLEXObjectExplorerViewController
[BaseType (typeof(FLEXObjectExplorerViewController))]
interface FLEXViewExplorerViewController
{
}

// @interface FLEXWebViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface FLEXWebViewController
{
	// -(id)initWithURL:(NSURL *)url;
	[Export ("initWithURL:")]
	IntPtr Constructor (NSUrl url);

	// -(id)initWithText:(NSString *)text;
	[Export ("initWithText:")]
	IntPtr Constructor (string text);

	// +(BOOL)supportsPathExtension:(NSString *)extension;
	[Static]
	[Export ("supportsPathExtension:")]
	bool SupportsPathExtension (string extension);
}
